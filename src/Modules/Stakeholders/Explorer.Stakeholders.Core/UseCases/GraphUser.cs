using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases
{
	public class GraphUser
	{
		public long Id { get; set; }
		public string Username { get; set; }

		public GraphUser(long id, string username) 
		{
			Id = id;
			Username = username;
		}
		

	}

}