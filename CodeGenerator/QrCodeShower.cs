using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CodeGenerator
{
	public partial class QrCodeShower : Form
	{
		public QrCodeShower(Bitmap qrImage)
		{
			InitializeComponent();
			pbQrCode.Image = qrImage;
			pbQrCode.SizeMode = PictureBoxSizeMode.StretchImage;
		}

		Image bmIm;
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			bmIm = pbQrCode.Image;
			var pd = new PrintDocument
			{
				OriginAtMargins = true,
				DefaultPageSettings = {Landscape = true}
			};
			pd.PrintPage += (sendera, args) =>
			{
				Point p = new Point(100, 100);
				args.Graphics.DrawImage(bmIm, 10, 10, bmIm.Width, bmIm.Height);
			};
			pd.Print();
		}
	}
}
