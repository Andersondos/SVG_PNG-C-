using System;
using System.Drawing;
using System.Drawing.Imaging;
using Svg;
using System.Xml;
using System.IO;
using System.Text;

public class Program
{
	public static void Main()
	{
		try
		{

			var nome = "Paulo ";
			var cargo = "Analista";
			var telefone = "11 4002-8922";
			var vazio = " ";


			var fileSvg = File.OpenText(@"C:\Users\anderson.santos\Pictures\ass_Oficial.svg");

			
			var svgTemplate = Svg.SvgDocument.Open(@"C:\Users\anderson.santos\Pictures\ass_Oficial.svg");  
			svgTemplate.ShapeRendering = SvgShapeRendering.Auto;

			var stream = new MemoryStream();
			svgTemplate.Write(stream);

			var textoSvg = Encoding.UTF8.GetString(stream.GetBuffer());
			textoSvg = fileSvg.ReadToEnd();
			textoSvg = textoSvg.Replace("[nome]", nome).Replace("[cargo]", cargo).Replace("[telefone]", telefone).Replace("[vazio]",vazio) ;
			File.WriteAllText(@"C:\Users\anderson.santos\Pictures\ass_temp.svg", textoSvg);

			var svgFinal = Svg.SvgDocument.Open(@"C:\Users\anderson.santos\Pictures\ass_{nome}.svg");  
			svgFinal.ShapeRendering = SvgShapeRendering.Auto;

			Bitmap bmp = svgFinal.Draw(1040,284);
			bmp.Save($@"C:\users\anderson.santos\\Pictures\ass_{nome}.png", ImageFormat.Png);               
			
			//File.Delete(@"C:\Users\anderson.santos\Pictures\ass_temp.svg");
		}
		catch (Exception ex)
		{

			throw ex;
		}
	}
}