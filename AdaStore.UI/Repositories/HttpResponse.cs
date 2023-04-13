﻿using System.Net;

namespace AdaStore.UI.Repositories
{
    public class HttpResponse<T>
    {
        public HttpResponse(bool error, T response, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }

        public async Task<string> GetErrorMessage()
        {
            if (!Error)
            {
                return null;
            }

            var codigoEstatus = HttpResponseMessage.StatusCode;

            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "Recurso no encontrado";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return "Tienes que loguearte para hacer esto";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para hacer esto";
            }
            else
            {
                return "Ha ocurrido un error inesperado";
            }
        }
    }
}
