
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Http;
using Spire.Barcode;

namespace BarcodeReader1.Controllers
{
    public class ValuesController : ApiController
    {

        // POST api/values for identifying the barcodes 
        public IHttpActionResult BarCodeReader([FromBody] string values)
        {
            byte[] image64String = Convert.FromBase64String(values);     
            Stream stream = new MemoryStream(image64String);

            var barcodeTypes = new[] {
            BarCodeType.EAN13,
            BarCodeType.Aztec,
            BarCodeType.Code11,
            BarCodeType.Code128,
            BarCodeType.EAN8,
            BarCodeType.Code39,
            BarCodeType.Interleaved25,
            BarCodeType.ITF14,
            BarCodeType.UPCA,
            BarCodeType.QRCode,
            BarCodeType.MicroQR,
            BarCodeType.UPCE,
            BarCodeType.USPS,
            BarCodeType.Code39Extended,
            BarCodeType.Code25,
            BarCodeType.DataMatrix,

            };

            var barcodes = new List<string>(); ;
            foreach (var barcodeType in barcodeTypes)
            {
                try
                {
                    string[] data = BarcodeScanner.Scan(stream, barcodeType, true);
                    barcodes.Add(barcodeType + ":" + data[0]);
                    
                }catch(Exception ex){
                    //barcodes.Add("Try with Invalid Format");
                }
            }
            return Ok(barcodes);
        }

    }
}
