using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class ReservationService : Service<Reservation>,IReservationService
	{
		public ReservationService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
		//implementation of methods
	}
}
