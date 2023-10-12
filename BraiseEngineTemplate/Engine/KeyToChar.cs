using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraiseEngineTemplate.Engine
{
	public class KeyToChar
	{
		public static char Convert(Keys key)
		{
			switch(key)
			{
				case Keys.A: return 'a';
				case Keys.B: return 'b';
				case Keys.C: return 'c';
				case Keys.D: return 'd';
				case Keys.E: return 'e';
				case Keys.F: return 'f';
				case Keys.G: return 'g';
				case Keys.H: return 'h';
				case Keys.I: return 'i';
				case Keys.J: return 'j';
				case Keys.K: return 'k';
				case Keys.L: return 'l';
				case Keys.M: return 'm';
				case Keys.N: return 'n';
				case Keys.O: return 'o';
				case Keys.P: return 'p';
				case Keys.Q: return 'q';
				case Keys.R: return 'r';
				case Keys.S: return 's';
				case Keys.T: return 't';
				case Keys.U: return 'u';
				case Keys.V: return 'v';
				case Keys.W: return 'w';
				case Keys.X: return 'x';
				case Keys.Y: return 'y';
				case Keys.Z: return 'z';
				case Keys.D0: return '0';
				case Keys.D1: return '1';
				case Keys.D2: return '2';
				case Keys.D3: return '3';
				case Keys.D4: return '4';
				case Keys.D5: return '5';
				case Keys.D6: return '6';
				case Keys.D7: return '7';
				case Keys.D8: return '8';
				case Keys.D9: return '9';
				case Keys.Enter: return '\n';
				case Keys.Space: return ' ';
			}

			return '\0';
		}
	}
}
