using System;
using System.Collections.Generic;

namespace BO
{
	public partial class FeedBack
	{
		public int Id { get; set; }
		public int GuestId { get; set; }
		public int PartyId { get; set; }
		public string Comment { get; set; } = null!;
		public DateTime ReviewDate { get; set; }

		public virtual Account Guest { get; set; } = null!;
		public virtual Party Party { get; set; } = null!;
	}
}