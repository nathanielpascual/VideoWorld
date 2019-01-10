﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoWorld.Models
{
	public class MembershipType
	{
		public int Id { get; set; }
		public short Discount { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }
	}
}