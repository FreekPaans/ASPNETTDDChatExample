using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication9.Models {
	public class ChatUser {
		public string Username{get;set;}
		public string Companyname{get;set;}
	}

	public class ChatRoomView {
		public string Username{get;set;}
		public string Companyname{get;set;}
		public ICollection<string> Messages{get; set;}		
	}

}