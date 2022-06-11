// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

namespace StarChallenge
{
	public class MainGame
	{
		//Think the orignal arrays are base 1
		//May need to bump these up to 6 or sub one off of the index
		private int[] C = new int[6]; //Think this is an array of alien ships
		private int[] H = new int[6];
		private int[] D = new int[6];
		private int[] F = new int[6];
		private int[] R = new int[6];
		private int[] T = new int[6];
		private int[] A = new int[6];

		//Messages
		private string pb = "PHASER BANKS"; //B$,
		private string ca = "CLOAK ACTIVATED**"; //C$
        private string alienName = "KLINGON"; //K$
		private string eng = "ENGINEERING REPORTS"; //E$
		private string pt = "PHOTON TOREPEDOES"; //P$
		private string dr = ", DAMAGE REPORT"; //D$
		private string hepb = "HIGH ENERGY PLASMA BOLT"; //H$
		private string dam = "DAMAGED"; // G$

		//Don't Know yet
		private float P = 0,  P3 = 1.5f, H1 = 0;//P = Power?
		private int R1 = 1;
		private int S = 0, M =0, D1= 0, N2 =0,  C1=0; 
		private int CINT = 0; //C
		private int RINT = 0; //R
		private int DInt = 0; //D
		private int FInt = 0; //F
		private int Q = new Random(0).Next();

		//Converted
		private int commandOption = 0; //M1
		private int shipToAttack = 0; //K
		private int numberOfAliens = 0; //N1

        public int D2 { get; private set; }

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

			if(numberOfAliens > 0 ) // GOTO 121
            {
				if (numberOfAliens < 6)//Line 131
				{
					WriteLine(String.Format("{0} {1}{2}", numberOfAliens, alienName, numberOfAliens ==1? "S": " ")); //Line 135
					if(numberOfAliens == 1) { H[1] = -3; }
				}
				else
				{
					WriteLine(String.Format("THE {0}S ONLY HAVE 5 BATTLE CRUSIERS IN THIS QUADRANT", alienName));
					numberOfAliens = 5;
				}

				Function143();

            }
		}

		private void PromptForNumberofEnemies() //Line 109
        {
			do
			{
				WriteLine("HOW MANY KLINGONS DO YOU WANT TO TAKE ON?", 1);
				string? count = Console.ReadLine();
				int test;

				if (count != null && int.TryParse(count, out test))
				{
					numberOfAliens = Math.Abs(test);
				}

			} while (numberOfAliens == 0 );
		}

		private void Function143()
        {
			WriteLine("COMING INTO RANGE - SHIELDS ON", 1);

			for(int i = 1; i<= numberOfAliens; i++)
            {
				R[i] = 40000 + (int) (new Random(1).Next(1,20001));
				A[i] = (int) new Random(1).Next(1, 361); //360 * new Random(1).Next();

				WriteLine(String.Format("RANGE OF {0}-{1} = {2} KM.AT {3} DEGREES", alienName, i, R[i], A[i]));
            }

			S = 0;
			P3 = 1.5f;
			R1 = 1;

			//goto 377
			function377();
        }

		private void PromptForUserInput() // Line 167
        {
			string? firingSolutions;

			do
			{
				WriteLine(String.Format("YOUR MOVE? DIRECTED AT {0}", alienName));  
				WriteLine(String.Format("ENTER COMMAND OPTION, SHIP NUMBER"));

				firingSolutions = Console.ReadLine();

			} while (!ValidUserCommand(firingSolutions));

            switch (commandOption) //Line 187
            {
				case 14:
					break;
				case 15:
					break;
				case 16:
					break;
				default:
					executeCommand();
					break;
            }
		}

        private void executeCommand()  //Line 189
        {
			bool commandSuceeded = false;

            switch (commandOption)
            {
				case 1:
				case 2:
					commandSuceeded = firePhasers();
					break;
            }

			//TODO: Translate the rest of command

            if (!commandSuceeded)
            {
				PromptForUserInput();
            }
        }

        private bool firePhasers() //Line 231
        {
            if (C[shipToAttack] == 1)
            {
				MoveImpossible();
				return false;
            }

			function233();
			return true;
        }

        private void MoveImpossible()
        {
			WriteLine("MOVE IMPOSSIBLE.  Try Again.",1);
        }

        private bool ValidUserCommand(string? userInput)
        {
			userInput = (userInput == null) ? "" : userInput;

			string[] commands = userInput.Split(",");

			if (commands.GetLength(0) != 2
				|| !int.TryParse(commands[1], out shipToAttack)
				|| !int.TryParse(commands[0], out commandOption))
			{
				return false;
			}

			commandOption = Math.Abs(commandOption);
			shipToAttack = Math.Abs(shipToAttack);

			if(commandOption > 16 || shipToAttack > numberOfAliens) //line 181 - 183
            {
				MoveImpossible();
				return false;
            }

			return true;
        }

		private void function143()
        {
			throw new NotImplementedException();
		}

		private void function181()
        {
			throw new NotImplementedException();
		}

		private void function233()
        {
			switch (commandOption) //Line 233
			{
				case 1:  //Line 235
                    if (R[shipToAttack] > 300000)
                    {
						MoveImpossible();
						return;
                    }

                    if (A[shipToAttack] > 180)
                    {
						MoveImpossible();
						return;
                    }

					if(H1 >= 8)
                    {
						MoveImpossible();
						return;
                    }

					float N3 = 2 / commandOption;
					P = P + N3;
					function975();
					break;
			}

			//TODO: Map remaining items
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

			PromptForUserInput(); //Line 165

			function975();  
			function537();  
		}

		private void SecondaryCircuitOverload()
		{
			WriteLine("SECONDARY DILITHIUM CIRCUIT FUSED");
			WriteLine("IMPLUSE POWER ONLY - LIMIT 2 MILLION STROMS");
			WriteLine("WARNING - IF CAPACITY OF IMPULSE ENGINE EXCEEDED IT,");
			WriteLine("EXPLODE ", 1);

			C1 = 2; // LINE 433

			function443();
		}

		private void PrimaryCircuitOverload() //Line 437
		{
			WriteLine("PRIMARY DILITHIUM CIRCUIT FUSED, SWITCHING TO SECONDARY");
			WriteLine("OVERLOAD CAPACITY FOR THIS CIRCUIT IS 10 MILLION STROMS", 1);
			C1 = 1; // LINE 441

			function443();
		}

		private void function443()
        {
			P = 0;
			if (commandOption == 5) //Fire Plasma Bolt
			{
				function457();
				return;
			}

			if (commandOption == 3)
			{ //Fire Front Phaser
				function453();
				return;
			}

			RINT = RINT - N2;
			PromptForUserInput();
		}

        private void function453()
        {
            throw new NotImplementedException();
        }

        private void function457()
        {
            throw new NotImplementedException();
        }

        private void function537()
        {
			if(H1 >= 9)
            {
				P = P - P3 - 0.5f;
            }
            else
            {

				P = P - P3;
			}

			TestForRepairs();
		}

        private void TestForRepairs() //Line 545
        {
            if(DInt > 4 || P3 == 2.5)
            {
				function605();
				return;
            }

			float Z1;

			for (int i = 0; i < R1; i++)
			{
				Z1 = H1 - .5f;

				if (Z1 > -1)//Line553
				{
					H1 = Z1;
                }
                else
                {
					H1 = -1;
					//Line 561
                }

				if(H1== 9.5)
                {
					if(C1 != 2)
                    {
						WriteLine(String.Format("{0} WARP ENGINES REPAIRED", eng),1);
                    }
                }

				EvaluateH1();
			}

			function605();
        }

		private void EvaluateH1()
        {
            switch (H1)
            {
				case 8.5f:
                    if (FInt < 20) {
						WriteLine(String.Format("{0} {1} PROJECTORS REPAIRED", eng,pt), 1);
					}

					if (RINT >= 10)
					{
						WriteLine(String.Format("{0} NORMAL POWERS LEVELS RESTORED", eng), 1);
					}
                    else
                    {
						WriteLine(String.Format("{0} {1} PROJECTORS REPAIRED", eng, pt), 1);
					}

					break;
				case 7.5f:
						WriteLine(String.Format("{0} {1} REPAIRED", eng, pb), 1);
					break;
				case 6.5f:
						WriteLine(String.Format("{0} SHEILDS RESTORED AT LOW POWER LEVEL", eng), 1);
					break;
				case 4.5f:
						WriteLine(String.Format("{0} SHEILDS FIRMING UP", eng), 1);
					break;
            }
        }

		private void function725()
        {
			if (DInt < 4 || DInt > 9)
			{
				return;
			}

			DInt = 10;
			WriteLine(String.Format("FURTHER REPAIRS IMPOSSIBLE"));
		}

        private void function605()
        {
			for (int k = 1; k < numberOfAliens; k++)
			{
				if (C[k] == 1)
				{
					D1 = +1;
					function725();
					continue;
				}

				if (CINT == 0)
				{
					if (R[k] <= 500000)
					{
						if (R[k] >= 100000)
						{
							if (R[k] >= 20000)
							{
								if (H[k] < 6)
								{
									R[k] = R[k] / 2;
									WriteLine(String.Format("{0} {1} APPROACHING", alienName, k));
									function725();
								}
							}
						}
					}
				}

				if (commandOption == 0)
				{
					WriteLine(String.Format("{0} {1} DOING NOTHING", alienName, k));
					continue;
				}

				if (H[k] > 5 || F[k] > 2)
                {
                    if (H[k] >= 7)
                    {

                    }


                }

            }

			throw new NotImplementedException();
		}

        private void function543()
        {
			throw new NotImplementedException();
		}

        private void function975()
        {
			if(CINT == 1)
            {
				P = P + 3;

				if(P <= 2) { return; }  // Line 979
				else if (C1 == 0) { PrimaryCircuitOverload(); }
				else if (C1 == 1) { SecondaryCircuitOverload(); }
				else if (C1 == 2 ) { ImpluseOverload(); }
				return;
            }

        }

        private void ImpluseOverload() //Line 909
        {
			WriteLine("IMPULSE ENGINE OVERLOAD", 1);

			function877();
		}

        private void function877()
        {
			R1 = 9800 * new Random().Next() + 200;
			WriteLine(String.Format("RADIUS OF EXPLOSION = {0} KM", R1), 1);

			for(int i = 1; i < numberOfAliens + 1; i++)
            {
                if (C[i]==1 || R[i] > R1)
                {
					continue;
                }

				if(R1 > R1 * .8)
                {
					H[i] = H[i] + 6;
                    if (H[i] < 8)
                    {
						F[i] = F[i] + 1;
						WriteLine(string.Format("{0} {1} HEAVILY {2}", alienName, i, dam), 1);
						continue;
                    }
                }

				WriteLine(String.Format("{0} {1} DESTROYED", alienName, i));

				C[i] = 1;
            }

			D2 = 1;

			function993();
		}

        private void function993()
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

