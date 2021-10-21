using HtmlAgilityPack;
using NwlEmployeeConsole.Models;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace NwlEmployeeConsole.Bussines
{
    public  class RenapoInfo 
    {

        public  string GetData(string curp)
        {
            var htmlDoc = new HtmlDocument();
            var client = new WebClient();
            Uri uri = new Uri($"http://www.renapo.sep.gob.mx/wsrenapo/MainControllerParam?curp={curp}");
            Stream data = client.OpenRead(uri);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            htmlDoc.LoadHtml(s);
            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body//table");
            var text = htmlBody.InnerText.ToString();
            string[] datos = text.Split("\r\n");
            var s2 = datos[17].Trim();
            var ap2 = Encoding.GetEncoding("iso-8859-1").GetString(Encoding.GetEncoding("iso-8859-1").GetBytes(s2));
            var renapo = new Renapo
            {
                AnioReg = datos[8].Trim(),
                Apellido1 = datos[13].Trim(),
                Apellido2 = ap2,
                Crip = datos[21].Trim(),
                Curp = datos[25].Trim(),
                CveEntidadEmisora = datos[29].Trim(),
                CveEntidadNac = datos[33].Trim(),
                CveMunicipioReg = datos[37].Trim(),
                DocProbatorio = datos[41].Trim(),
                FechNac = datos[45].Trim(),
                Foja = datos[49].Trim(),
                FolioCarta = datos[53].Trim(),
                Libro = datos[57].Trim(),
                Nacionalidad = datos[61].Trim(),
                Nombres = datos[65].Trim(),
                NumActa = datos[69].Trim(),
                NumEntidadReg = datos[73].Trim(),
                NumRegExtranjeros = datos[77].Trim(),
                Sexo = datos[81].Trim(),
                StatusCurp = datos[85].Trim(),
                Tomo = datos[89].Trim()
            };

            string jsonString = JsonSerializer.Serialize(renapo);
            return jsonString;
        }


    }

}