using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Adventure.Services;

namespace Adventure.Controllers
{
	[ApiController]
	[Route("/api/[controller")]
	public class MessagesController : ControllerBase
	{
		#region Controller Configuration
		private readonly MessagesService _ms;
		public MessagesController(MessagesService ms)
		{
			_ms = ms;
		}
		#endregion
	}
}