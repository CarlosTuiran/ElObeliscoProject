using Aplicacion.Request;
using Domain.Models.Contracts;
using Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacion.Services.ConsultarServices
{
    public class ConsultarFechaService
    {
        readonly IUnitOfWork _unitOfWork;
        public ConsultarFechaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int ConsultarFecha(DateTime fecha) 
        {
            var tiempo = _unitOfWork.TiempoServiceRepository.FindFirstOrDefault(t => t.Fecha == fecha);
            if (tiempo == null) 
            {
                return 0;
            }
            else 
            {
                return tiempo.Id;
            }
        }
    }
}
