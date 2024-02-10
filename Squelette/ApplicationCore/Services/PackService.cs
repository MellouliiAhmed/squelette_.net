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
	public class PackService : Service<Pack>,IPackService
	{
		public PackService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}
		//implementation of methods
	}
}
