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
	public class ClientService : Service<Client>,IClientService
	{
		public ClientService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{
		}

        public float montantClient(Client client)
        {
            return 0;
        }
        //implementation of methods
    }
}
