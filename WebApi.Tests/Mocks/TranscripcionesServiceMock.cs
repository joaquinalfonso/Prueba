﻿using System;
using System.Collections.Generic;
using System.Web;
using WebApi.Comun;
using WebApi.Models;
using WebApi.Servicios;

namespace Tests.Mocks
{
    public class TranscripcionesServiceMock : ITranscripcionesService
    {
        private List<Transcripcion> testTranscripciones = new List<Transcripcion>();

        public TranscripcionesServiceMock()
        {
            
            testTranscripciones.Add(new Transcripcion { Id = 1, FechaHoraRecepcion = DateTime.Now, LoginUsuario = "Usuario1", NombreArchivo = "Archivo1.mp3", Estado = TipoEstadoTranscripcion.PENDIENTE.ToString() });
            testTranscripciones.Add(new Transcripcion { Id = 2, FechaHoraRecepcion = DateTime.Now.AddDays(-1), LoginUsuario = "Usuario1", NombreArchivo = "Archivo2.mp3", Estado = TipoEstadoTranscripcion.PENDIENTE.ToString() });
            testTranscripciones.Add(new Transcripcion { Id = 3, FechaHoraRecepcion = DateTime.Now.AddDays(-2), LoginUsuario = "Usuario2", NombreArchivo = "Archivo3.mp3", Estado = TipoEstadoTranscripcion.PENDIENTE.ToString() });

        }

        public void ActualizarTranscripcion(Transcripcion transcripcion)
        {
            throw new NotImplementedException();
        }

        public void InsertarTranscripcion(Transcripcion transcripcion)
        {
            throw new NotImplementedException();
        }

        public int ObtenerNuevoIdTranscripcion()
        {
            throw new NotImplementedException();
        }

        

        public List<TranscripcionDTO> ObtenerTranscripciones(ParametrosConsultaTranscripcionesTO parametros)
        {
            List<TranscripcionDTO> listaTranscripciones = new List<TranscripcionDTO>();
            testTranscripciones.ForEach(x => listaTranscripciones.Add(new TranscripcionDTO(x)));

            return listaTranscripciones;
        }

        public void ProcesarTranscripcion(Transcripcion transcripcion)
        {
            throw new NotImplementedException();
        }

        public void ProcesarTranscripciones(List<Transcripcion> transcripciones)
        {
            throw new NotImplementedException();
        }

        public void ProcesarTranscripcionesPendientes()
        {
            throw new NotImplementedException();
        }

       

        public void RecibirFicheroATranscribir(HttpPostedFile fichero, string login)
        {
            throw new NotImplementedException();
        }

        public string ObtenerTextoTranscripcionRealizada(int id, string login)
        {
            if (id == 0)
                return "Texto";

            if (id == -1)
                throw new TranscripcionNoEncontradaException();

            if (id == -2)
                throw new TranscripcionPendienteException();

            if (id == -3)
                throw new TranscripcionErroneaException();

            throw new NotImplementedException();
        }
    }
}
