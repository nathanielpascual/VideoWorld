using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoWorld.Models
{
	public class Genre
	{
		public int Id { get; set; }

		[Required]
		[StringLength(25)]
		public string Name { get; set; }
	}
}