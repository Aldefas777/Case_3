using ClassLibrary.Interfaces;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ClassLibrary.Classes
{
    public class QRClass : IQRClass
    {

        public string Create(string inputText)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator oQRCodeGenerator = new QRCodeGenerator();
                QRCodeData oQRCodeData = oQRCodeGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q);
                QRCode oQRCode = new QRCode(oQRCodeData);
                using (Bitmap oBitmap = oQRCode.GetGraphic(20))
                {
                    oBitmap.Save(ms, ImageFormat.Png);
                    string  QRCode1 = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    return (QRCode1);
                }
            }
        }
    }
}
