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
	public class ActiviteService : Service<Activite>,IActiviteService
	{
		public ActiviteService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
		//implementation of methods
	}
}
