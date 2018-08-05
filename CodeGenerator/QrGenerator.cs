using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using QRCoder;

namespace CodeGenerator
{
	public partial class QrGenerator : Form
	{
		public QrGenerator()
		{
			InitializeComponent();
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			var data = new QrCodeModel();
			data.CustomerName = tbName.Text;
			data.CustomerSurname = tbSurname.Text;
			data.CustomerAddress = tbAddress.Text;
			data.Brand = tbBrand.Text;
			data.Model = tbModel.Text;
			data.SerialNumber = tbSerialNumber.Text;
			var qrCodeImage = GenerateQrImage(data);
			var shower = new QrCodeShower(qrCodeImage);
			shower.ShowDialog();
		}

		private Bitmap GenerateQrImage(QrCodeModel data)
		{
			var jsonData = JsonConvert.SerializeObject(data);
			var qrGenerator = new QRCodeGenerator();
			var qrCodeData = qrGenerator.CreateQrCode(jsonData, QRCodeGenerator.ECCLevel.Q);
			var qrCode = new QRCode(qrCodeData);
			var qrCodeImage = qrCode.GetGraphic(100);
			return qrCodeImage;
		}
	}
}
