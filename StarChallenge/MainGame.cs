using System;
using System.Text;

namespace StarChallenge
{
	public class MainGame
	{
		private int[] C = new int[5];
		private int[] H = new int[5];
		private int[] D = new int[5];
		private int[] F = new int[5];
		private int[] R = new int[5];
		private int[] T = new int[5];
		private int[] A = new int[5];

		//Messages
		private string pb = "PHASER BANKS"; //B$,
		private string ca = "CLOAK ACTIVATED**"; //C$
        private string alienName = "KLINGON"; //K$
		private string eng = "ENGINEERING REPORTS"; //E$
		private string pt = "PHOTON TOREPEDOES"; //P$
		private string dr = ", DAMAGE REPORT"; //D$
		private string hepb = "HIGH ENERGY PLASMA BOLT"; //H$
		private string dam = "DAMAGED"; // G$
		
		private float P3 = 1.5f;
		private int R1 = 1;
		private int S = 0, M =0, D1= 0, N2 =0, P=0, C1=0;
		private int CINT = 0; //C
		private int Q = new Random(0).Next();

		private int commandOption = 0; //M1
		private int shipToAttack = 0; //K

		private int numberOfKlingons = 0; //N1

		public MainGame()
		{
		}

		public void Start()
        {
			CreateMainTitle();
			CreateIntroduction();
        }

		private void CreateMainTitle()
        {
			StringBuilder sb = new StringBuilder();

			sb.AppendLine("SPACE--THE FINAL FRONTIER.");
			sb.AppendLine("THESE ARE THE VOYAGES OF THE  STARSHIP ENTERPRISE,");
			sb.AppendLine("HER 5 YEAR MISSSION --");
			sb.AppendLine("TO EXPLORE STRANGE NEW WORLDS");
			sb.AppendLine("TO SEEK OUT NEW LIFE AND CIVILIZATIONS");
			sb.AppendLine("TO BOLDLY GO WHERE NO ONE HAS GONE BEFORE");
			sb.AppendLine("(SWISH, TRUMPETS)");

			WriteLine(sb.ToString(), 2);
		}

		private void CreateIntroduction()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat("YOU ARE ON PATROL IN ARCTURUS SECTOR {0} "  , Q);
			sb.AppendLine("");
			sb.AppendLine("WHEN YOU PICKUP UNEXPECTED SENSOR READINGS, ");
			sb.AppendLine(String.Format("CONFIURATION -- {0} BATTLE CRUISERS", alienName));
			sb.AppendLine("DO YOU NEED A SUMMARY OF YOUR SHIPS CAPABILITIES ?");


			WriteLine(sb.ToString(), 2);

			string? response = Console.ReadLine();
			if(response != null)
            {
				response = response.ToLower().Trim();

                switch (response)
                {
					case "yes":
					case "y":
						CreateInstrunctions();
						break;
					default:
						SetNumberOfEnemies();
						break;
                }
			}
		}

		private void CreateInstrunctions()
        {
			//Resume at line 00073
        }

		private void SetNumberOfEnemies()
		{
			PromptForNumberofEnemies();

			if(numberOfKlingons > 0 ) // GOTO 121
            {
				if(numberOfKlingons < 6 ) //GOTO 129
                {
					if(numberOfKlingons == 1) //Line 129
                    {
						//GOTO 139
						WriteLine(String.Format("{0} {1}", numberOfKlingons, alienName)); //Line 139
						H[1] = -3;
						//GOTO 143
					}

					if(numberOfKlingons > 2)//Line 131
                    {
					
						WriteLine(String.Format("{0} {1}S", numberOfKlingons, alienName)); //Line 135
						//GOTO 143
					}

					return;
                }

				WriteLine(String.Format("THE {0}S ONLY HAVE 5 BATTLE CRUSIERS IN THIS QUADRANT", alienName));
				numberOfKlingons = 5;
				//GOTO 143

            }
		}

		private void PromptForNumberofEnemies() //Line 109
        {
			do
			{
				WriteLine("HOW MANY KLINGONS DO YOU WANT TO TAKE ON?", 1);
				string? count = Console.ReadLine();
				int test = 0;

				if (count != null && int.TryParse(count, out test))
				{
					numberOfKlingons = Math.Abs(test);
				}

			} while (numberOfKlingons == 0 );
		}

		private void Function143()
        {
			WriteLine("COMING INTO RANGE - SHIELDS ON", 1);

			for(int i = 1; i<= numberOfKlingons; i++)
            {
				R[i] = 40000 + (new Random(1).Next() * 20000);
				A[i] = 360 * new Random(1).Next();

				WriteLine(String.Format("RANGE OF {0}-{1} = {2} KM.AT {3} DEGREES", alienName, i, R[i], A[i]));
            }

			S = 0;
			P3 = 1.5f;
			R1 = 1;

			//goto 377
			function377();
        }

		private void function165()
        {
			string? firingSolutions = "";

			do
			{
				WriteLine(String.Format("YOUR MOVE? DIRECTED AT {0}", alienName));
				WriteLine(String.Format("ENTER COMMAND OPTION, SHIP NUMBER"));

				firingSolutions = Console.ReadLine();

				firingSolutions = (firingSolutions == null) ? "" : firingSolutions;

				string[] commands = firingSolutions.Split(",");

				if (commands.GetLength(0) != 2
					&& !int.TryParse(commands[1], out shipToAttack)
					&& !int.TryParse(commands[0], out commandOption)
				)
                {
					firingSolutions = String.Empty;
				}


			} while (firingSolutions == "");

			if(commandOption > 0)
            {
				function181();
				return;
            }

			function975();
			function537();
        }

		private void function181()
        {
			throw new NotImplementedException();
		}

		private void function373()
        {
			throw new NotImplementedException();
		}

		private void function367()
        {
			throw new NotImplementedException();
		}

		private void function377()
        {
			WriteLine(ca);
			if (CINT != 1) function381();
        }

		private void function381()
        {
			if(P3 == 2.5)
            {
				function373();
				return;
            }

			if(P3 == .5)
            {
				function367();
				return;
            }

			function165();
        }

		private void function425()
		{
			throw new NotImplementedException();
		}

		private void function437()
		{
			throw new NotImplementedException();
		}

		private void function537()
        {
			throw new NotImplementedException();
		}

		private void function975()
        {
			if(CINT == 1)
            {
				P = P + 3;

				if(P <= 20) { function983(); }
				else if (C1 == 0) { function437(); }
				else if (P <= 10) { function987(); }
				else if (C1 == 1) { function425(); }
				else if (P <= 2) { function991(); }
				else if (C1 ==2 ) { function909(); }
				return;
            }

			function979();
        }

        private void function909()
        {
            throw new NotImplementedException();
        }

		private void function979()
		{
			throw new NotImplementedException();
		}

		private void function983()
		{
			throw new NotImplementedException();
		}

		private void function987()
        {
            throw new NotImplementedException();
        }

		private void function991()
		{
			throw new NotImplementedException();
		}

        private void WriteLine(string text, int blankLinesAfter = 0 )
        {
			Console.WriteLine(text);

			for(int i = 0; i < blankLinesAfter; i++)
            {
				Console.WriteLine(" ");
            }
        }
	}
}

