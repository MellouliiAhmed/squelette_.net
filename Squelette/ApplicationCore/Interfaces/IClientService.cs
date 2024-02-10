using ApplicationCore.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface IClientService : IService<Client>
	{
		//signature des méthodes
		public float montantClient(Client client);

	}
}
