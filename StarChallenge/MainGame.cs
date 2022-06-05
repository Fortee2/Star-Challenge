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
        private string k = "KLINGON"; //K$
		private string eng = "ENGINEERING REPORTS"; //E$
		private string pt = "PHOTON TOREPEDOES"; //P$
		private string dr = ", DAMAGE REPORT"; //D$
		private string hepb = "HIGH ENERGY PLASMA BOLT"; //H$
		private string dam = "DAMAGED"; // G$

		private float P3 = 1.5f;
		private int R1 = 1;
		private int Q = new Random(0).Next();

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
			sb.AppendLine("CONFIURATION -- KLINGON BATTLE CRUISERS");
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
						SetNumberOfEntities();
						break;
                }
			}
		}

		private void CreateInstrunctions()
        {
			//Resume at line 00073
        }

		private void SetNumberOfEntities()
		{
			PromptForNumberofEnemies();

			if(numberOfKlingons > 0 ) // GOTO 121
            {
				if(numberOfKlingons < 6 ) //GOTO 129
                {
					if(numberOfKlingons == 1) //Line 129
                    {
						//GOTO 139
						WriteLine(String.Format("{0} {1}", numberOfKlingons, k)); //Line 139
						//GOTO 143
					}

					if(numberOfKlingons > 2)//Line 131
                    {
					
						WriteLine(String.Format("{0} {1}S", numberOfKlingons, k)); //Line 135
						//GOTO 143
					}

					return;
                }

				WriteLine("THE KLINGONS ONLY HAVE 5 BATTLE CRUSIERS IN THIS QUADRANT");
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

