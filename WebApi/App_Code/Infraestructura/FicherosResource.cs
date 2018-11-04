﻿using System.IO;
using System.Web;
using WebApi.Comun;

namespace WebApi.Infraestructura
{

    // Clase de recursos que implementa la capa de operaciones de almacenamiento en disco.
    // Implementa la interface IFicherosResource

    public class FicherosResource : IFicherosResource
    {

        private string ObtenerRutaFicheroTranscritoTxt(int id)
        {
            string rutaFicherosTranscripciones = System.Web.Hosting.HostingEnvironment.MapPath(Configuracion.RUTA_FICHEROS_TRANSCRITOS);
            var rutaFicheroTxt = rutaFicherosTranscripciones + string.Format("{0}.txt", id);
            return rutaFicheroTxt;
        }

        public bool ExisteFicheroTranscritoTxt(int id)
        {
            string rutaFicheroTxt = ObtenerRutaFicheroTranscritoTxt(id);
            return File.Exists(rutaFicheroTxt);
        }

        public void GrabarFicheroTextoTranscrito(int id, string textoTranscrito)
        {
            string rutaFicheroTranscrito = ObtenerRutaFicheroTranscritoTxt(id);
            File.WriteAllText(rutaFicheroTranscrito, textoTranscrito, System.Text.Encoding.UTF8);
        }


        private string ObtenerRutaFicheroMp3(int id)
        {
            string rutaFicherosMp3 = System.Web.Hosting.HostingEnvironment.MapPath(Configuracion.RUTA_FICHEROS_MP3);
            return string.Format("{0}{1}{2}", rutaFicherosMp3, id, Configuracion.EXTENSION_FICHEROS_AUDIO.ToLower());
        }

        public byte[] ObtenerFicheroMp3(int id)
        {
            string rutaFicheroMp3 = ObtenerRutaFicheroMp3(id);

            byte[] ficheroMp3 = File.ReadAllBytes(rutaFicheroMp3);

            return ficheroMp3;
        }

        public string ObtenerFicheroTranscritoTxt(int id)
        {
            string rutaFicheroTxt = ObtenerRutaFicheroTranscritoTxt(id);

            string contenidoFicheroTxt = "";
            contenidoFicheroTxt = File.ReadAllText(rutaFicheroTxt, System.Text.Encoding.UTF8);

            return contenidoFicheroTxt;
        }

        public void GrabarFicheroMp3(HttpPostedFile postedFile, int idTranscripcion)
        {
            string rutaGuardado = HttpContext.Current.Server.MapPath(Configuracion.RUTA_FICHEROS_MP3);
            var filePath = rutaGuardado + string.Format("{0}{1}", idTranscripcion, Configuracion.EXTENSION_FICHEROS_AUDIO.ToLower());

            postedFile.SaveAs(filePath);
        }
    }
}