namespace Generic.Steps.Helpers.Interfaces
{
	public interface IImageStepHelper : IStepHelper
	{
		bool Compared(string firstImage, string secondImage, double percentAccept = 99.99);
		bool ClickOnImageInImage(string subImage, string image);
		bool ImageExistsInImage(string subImage, string image);
	}
}
