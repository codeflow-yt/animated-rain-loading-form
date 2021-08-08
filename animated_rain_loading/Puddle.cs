using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animated_rain_loading
{
	public class Puddle
	{
		private int percentage = 0;

		public PictureBox View { get; set; }

		public Puddle(PictureBox view)
		{
			View = view;
		}

		public int Percentage
		{
			get
			{
				return percentage;
			}
			set
			{
				percentage = value < 0 ? 0 : value;
				percentage = value > 100 ? 100 : value;

				View.Top = View.Parent.Height - (percentage * (View.Height / 2) / 100);
			}
		}
	}
}
