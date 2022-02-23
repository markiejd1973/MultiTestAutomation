
using System.Drawing;
using TechTalk.SpecFlow;
using Core.Logging;
using Core;
using Generic.Steps.Helpers.Interfaces;

namespace Generic.Steps.Helpers.Classes
{
	public class ImageStepHelper : StepHelper, IImageStepHelper
	{
		private readonly ITargetForms targetForms;
		public ImageStepHelper(FeatureContext featureContext, ITargetForms targetForms) : base(featureContext)
		{
			this.targetForms = targetForms;
		}

		/// <summary>
		/// Used as a counter to see how many pixels matched in a failure
		/// </summary>
		int maxPixels = 0;

		/// <summary>
		/// Does a subImage exist in an Image
		/// </summary>
		/// <param name="subImage"></param>
		/// <param name="image"></param>
		/// <returns></returns>
		public bool ImageExistsInImage(string subImage, string image)
		{
			DebugOutput.Log($"Proc - ImageExistsInElement {subImage} {image}");
			var imageLocation = ImageLocationInImage(subImage, image);

			if (imageLocation == null)
			{
				DebugOutput.Log($"Did not find {subImage} in {image}");
				return false;
			}

			DebugOutput.Log($"Found image within image @ {imageLocation}");
			return true;
		}

		public bool ClickOnImageInImage(string subImage, string image)
		{
			DebugOutput.Log($"Proc - ClickOnImageInImage {subImage} {image}");
			var imageElementLocator = CurrentPage.Elements[image];
			var imageElement = SeleniumUtil.GetElement(imageElementLocator);
			if (imageElement == null)
			{
				DebugOutput.Log($"Not finding an element called {image} in current page {CurrentPage.Name}");
				return false;
			}

			var imageLocation = ImageLocationInImage(subImage, image);

			if (imageLocation == null)
			{
				DebugOutput.Log($"Did not find {subImage} in {image}");
				return false;
			}

			DebugOutput.Log($"Found image within image @ {imageLocation} Need to get it as an element");

			imageElementLocator = CurrentPage.Elements[image];
			imageElement = SeleniumUtil.GetElement(imageElementLocator);
			//var imageElementLocator = imageElementId.Locator;
			//var imageElement = SeleniumUtilities.GetElement(imageElementLocator, 2);

			if (imageElement == null)
			{
				DebugOutput.Log($"Failed to find the element for {image}");
				return false;
			}

			var coordinates = imageLocation.Split(",");

			if (coordinates.Length < 1)
			{
				DebugOutput.Log($"Something wrong with the returned string {imageLocation}");
			}

			string fileDirectorySubImage = SeleniumUtil.compareFolder + "\\ImageComparison\\";
			var bitmapOfSubImage = $"{fileDirectorySubImage}{subImage}.png";
			var subImageImg = Image.FromFile(bitmapOfSubImage);
			var subImageWidth = subImageImg.Width;
			var subImageHeight = subImageImg.Height;
			int x = 0;
			int y = 0;

			if (Int32.TryParse(coordinates[0], out int numberX))
			{
				x = numberX + (subImageWidth / 2);
				DebugOutput.Log($"X is set to {x}");
			}
			else
			{
				DebugOutput.Log($"Failed to convert to X number {coordinates[0]}");
				return false;
			}

			if (Int32.TryParse(coordinates[1], out int numberY))
			{
				y = numberY + (subImageHeight / 2);
				DebugOutput.Log($"Y is set to {y}");
			}
			else
			{
				DebugOutput.Log($"Failed to convert to Y number {coordinates[0]}");
				return false;
			}

			DebugOutput.Log($"Move and Click on {image} using locator {imageElementLocator} offset {x},{y}");
			return SeleniumUtil.ClickCoordinates(imageElement, x, y);
		}

		/// <summary>
		/// Finds the x,y of the first pixel of a subimage within an image
		/// </summary>
		/// <param name="subImage"></param>
		/// <param name="image"></param>
		/// <returns></returns>
		private string ImageLocationInImage(string subImage, string image)
		{
			DebugOutput.Log($"Proc - ImageExistsInElement {subImage} {image}");
			string fileDirectorySubImage = SeleniumUtil.compareFolder + "\\ImageComparison\\";
			string fileDirectoryImage = SeleniumUtil.outputFolder;
			var bitmapOfImage = $"{fileDirectoryImage}{image}.png";
			var bitmapOfSubImage = $"{fileDirectorySubImage}{subImage}.png";
			DebugOutput.Log($"Parent Image = {bitmapOfImage}");
			DebugOutput.Log($"Sub Image = {bitmapOfSubImage}");

			if (!File.Exists(bitmapOfImage))
			{
				DebugOutput.Log($"bitmapOfImage NOT EXIST!");
				return null;
			}

			if (!File.Exists(bitmapOfSubImage))
			{
				DebugOutput.Log($"bitmapOfSubImage NOT EXIST!");
				return null;
			}
			DebugOutput.Log($"We have the files!");
			var subImageMatrix = getBitmapColorMatrix(bitmapOfSubImage);
			var imageMatrix = getBitmapColorMatrix(bitmapOfImage);
			var firstPixelToFind = subImageMatrix[0, 0];

			for (int x = 0; x <= imageMatrix.GetLength(0) - subImageMatrix.GetLength(0); x++)
			{
				for (int y = 0; y <= imageMatrix.GetLength(1) - subImageMatrix.GetLength(1); y++)
				{
					DebugOutput.Log($"Checking THIS x={x}  y={y}  color={imageMatrix[x, y]}");

					if (imageMatrix[x, y] == firstPixelToFind)
					{
						if (FindSubImage(subImageMatrix, imageMatrix, x, y))
						{
							DebugOutput.Log($"Match {x},{y}");
							return $"{x},{y}";
						}

						DebugOutput.Log($"nope - wasn't!");
					}
				}
			}

			DebugOutput.Log($"cycle FAILED!");
			return null;
		}

		/// <summary>
		/// Matched the 1st pixel check the rest
		/// </summary>
		/// <param name="subImageMatrix"></param>
		/// <param name="imageMatrix"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool FindSubImage(Color[,] subImageMatrix, Color[,] imageMatrix, int x, int y)
		{
			DebugOutput.Log($"Proc - FindSubImage {subImageMatrix} {imageMatrix} {x} {y}");
			var totalPixels = subImageMatrix.GetLength(0) * subImageMatrix.GetLength(1);
			int startX = x;
			int startY = y;
			int counter = 0;
			int subImageCounter0 = subImageMatrix.GetLength(0);
			int subImageCounter1 = subImageMatrix.GetLength(1);
			int totalCount = subImageCounter0 + subImageCounter1;

			for (int loopSubImageX = 0; loopSubImageX < subImageMatrix.GetLength(0) - 1; loopSubImageX++)
			{
				y = startY;

				for (int loopSubImageY = 0; loopSubImageY < subImageMatrix.GetLength(1) - 1; loopSubImageY++)
				{
					if (subImageMatrix[loopSubImageX, loopSubImageY] != imageMatrix[x, y])
					{
						if (maxPixels < counter)
						{
							maxPixels = counter;
						}

						DebugOutput.Log($"Failed on counter {counter} OF {totalCount}");
						return false;
					}

					counter++;
					y++;
				}

				x++;
			}

			DebugOutput.Log($"think this is a match!!!!!!!!!!!!!! {counter} pixels MATCHED");
			return true;
		}

		/// <summary>
		/// Get a matrix of color for a file
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private Color[,] getBitmapColorMatrix(string filePath)
		{
			DebugOutput.Log($"Proc - getBitmapColorMatrix {filePath} ");
			Bitmap bmp = new Bitmap(filePath);
			Color[,] matrix;
			int height = bmp.Height;
			int width = bmp.Width;
			matrix = new Color[width, height];

			for (int x = 0; x <= bmp.Width - 1; x++)
			{
				for (int y = 0; y < bmp.Height - 1; y++)
				{
					matrix[x, y] = bmp.GetPixel(x, y);
				}
			}

			return matrix;
		}

		/// <summary>
		/// Compare two exact sized images true if same within acceptable range
		/// </summary>
		/// <param name="firstImage"></param>
		/// <param name="secondImage"></param>
		/// <param name="percentAccept"></param>
		/// <returns></returns>
		public bool Compared(string firstImage, string secondImage, double percentAccept = 99.99)
		{
			DebugOutput.Log($"Proc - Compared {firstImage} {secondImage} {percentAccept}");
			var directory = Directory.GetCurrentDirectory();
			DebugOutput.Log($"My current directory is ... {directory}!");
			const string fileDirectory = "..\\..\\..\\TestUploadFiles\\ImageComparison\\";
			const string fileDirectoryNew = "..\\..\\..\\test-results\\";
			DebugOutput.Log($"Create bitmaps");
			var img1 = new Bitmap($"{fileDirectory}{firstImage}.png");
			var img2 = new Bitmap($"{fileDirectoryNew}{secondImage}.png");
			DebugOutput.Log($"Comparing");

			if ((img1 == null) || (img2 == null))
			{
				DebugOutput.Log($" {fileDirectory} does not have the file {firstImage} or {secondImage}");
				return false;
			}

			DebugOutput.Log($"We have 2 images to compare");

			if (img1.Size != img2.Size)
			{
				DebugOutput.Log($"Images are of different sizes");
				return false;
			}

			DebugOutput.Log($"They ARE the same size - taken at same resolution");
			var percentageDiff = GetPixelDifference(img1, img2);

			if (percentageDiff != 0)
			{
				DebugOutput.Log($"Image is {percentageDiff} different - acceptable level is {percentAccept}");
				float percentSame = 100 - percentageDiff;

				if (percentSame < percentAccept)
				{
					DebugOutput.Log($"Would accept {percentAccept}% but we have {percentSame}%");
					return false;
				}

				DebugOutput.Log($"We are within acceptable level of Pixels {percentSame}% being the same");
			}
			else
			{
				DebugOutput.Log($"Exactly the same image!");
			}

			return true;
		}

		/// <summary>
		/// Count pixels differences
		/// </summary>
		/// <param name="img1"></param>
		/// <param name="img2"></param>
		/// <returns></returns>
		private float GetPixelDifference(Bitmap img1, Bitmap img2)
		{
			DebugOutput.Log($"Proc - GetPixelDifference {img1} {img2}");
			float diff = 0;
			int numberOfPixels = 0;

			for (int y = 0; y < img1.Height; y++)
			{
				for (int x = 0; x < img1.Width; x++)
				{
					numberOfPixels++;
					var pixel1 = img1.GetPixel(x, y);
					var pixel2 = img2.GetPixel(x, y);

					if (pixel1 != pixel2)
					{
						diff++;
					}
				}
			}

			DebugOutput.Log($"Numbr of Pixels = {numberOfPixels}");
			DebugOutput.Log($"Number of Pixels different = {diff}");
			var percentDifferent = (diff / numberOfPixels) * 100;
			return percentDifferent;
		}
	}
}
