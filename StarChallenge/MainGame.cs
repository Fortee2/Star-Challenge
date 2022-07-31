﻿// See https://aka.ms/new-console-template for more information
using System;
using System.Text;

namespace StarChallenge
{
	public class MainGame
	{
		private int[] _enemyShips = new int[6]; //ATTACKING SHIPS C[]
		private int[] H = new int[6];
		private int[] D = new int[6];
		private int[] F = new int[6];
		private int[] _enemyDistance = new int[6]; //ENEMY Distance kilometers R[]
		private int[] _enemyPhotonTorpedos = new int[6]; //ENEMY PHASER BANK T[]
		private int[] _enemyDirection = new int[6]; //Enemy direction in degrees A[]

		//Messages
		private string pb = "PHASER BANKS"; //B$,
		private readonly string _cloakActivated = "CLOAK ACTIVATED**"; //C$
        private string alienName = "KLINGON"; //K$
		private string eng = "ENGINEERING REPORTS"; //E$
		private string pt = "PHOTON TOREPEDOES"; //P$
		private string dr = ", DAMAGE REPORT"; //D$
		private string hepb = "HIGH ENERGY PLASMA BOLT"; //H$
		private string dam = "DAMAGED"; // G$

		//Don't Know yet
		private float P = 0,  P3 = 1.5f;//P = Power? 
		private int R1 = 1, B1=0, B2=0, H1-0;
		private int S = 0, M =0, D1= 0, N2 =0,  C1=0; 
		private int CINT = 0; //C  Toggle if Cloak is activate?
		private int RINT = 0; //R  Radius
		private int DInt = 0; //D
		private int FInt = 0; //F
		private int Q = new Random(0).Next();  //Quadrant

		//Converted
		private int _commandOption = 0; //M1
		private int _shipToAttack = 0; //K
		private int _numberOfAliens = 0; //N1
		private float _hitsTaken = 0; //hitsTaken

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

				//Control loop
				do
				{
					PromptForUserInput();
				} while (_hitsTaken < 11);
			}
		}

		private void CreateInstrunctions()
        {
			//TODO:Resume at line 00073

        }

		private void SetNumberOfEnemies()
		{
			PromptForNumberofEnemies();

			if (_numberOfAliens < 6)//Line 131
			{	
				if(_numberOfAliens == 1) {S = H[1] = -3; }
			}
			else
			{
				_numberOfAliens = 5;
			}

			WriteLine(String.Format("{0} {1}{2}", _numberOfAliens, alienName, _numberOfAliens == 1 ? "S" : " ")); //Line 135
			Function143();
			
		}

		private void PromptForNumberofEnemies() //Line 109
        {
			do
			{
				WriteLine("HOW MANY KLINGONS DO YOU WANT TO TAKE ON?", 1);
				string? count = Console.ReadLine();

                if (count != null && int.TryParse(count, out int test))
                {
                    _numberOfAliens = Math.Abs(test);
                }

            } while (_numberOfAliens == 0 );
		}

		private void Function143()
        {
            WriteLine("COMING INTO RANGE - SHIELDS ON", 1);

            PrintEnemyRange();

            S = 0;
            P3 = 1.5f;
            R1 = 1;

            //goto 377
            function377();
        }

        private void PrintEnemyRange()
        {
            for (int i = 1; i <= _numberOfAliens; i++)
            {
                _enemyDistance[i] = 40000 + (int)(new Random().Next(1, 20001));
                _enemyDirection[i] = (int)new Random().Next(1, 361); //360 * new Random(1).Next();

                WriteLine(String.Format("RANGE OF {0}-{1} = {2} KM AT {3} DEGREES", alienName, i, _enemyDistance[i], _enemyDirection[i]));
            }
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

       
			ExecuteCommand();
		}

        private void ExecuteCommand()  //Line 189
        {
			bool commandSuceeded = false;

            switch (_commandOption)
            {
				case 1:
				case 2:
					commandSuceeded = firePhasers();
					break;
				case 3:
					function191();
					break;
				case 4:
					function197();
					break;
				case 5:
				case 8:
					function231();
					break;
				case 6:
				case 7:
				case 9:
				case 10:
				case 11:
					function233();
					break;
				case 12:
					function341();
					break;
				case 13:
					function349();
					break;
				case 14:   //Line 187
					function363();
					break;
				case 15:
					function371();
					break;
				case 16:
					function159();
					break;
				default:
					function975();
					break;
                    
            }


            if (!commandSuceeded)
            {
				PromptForUserInput();
            }
        }

        private void function159()
        {
            throw new NotImplementedException();
        }

        private void function371()
        {
            throw new NotImplementedException();
        }

        private void function363()
        {
            throw new NotImplementedException();
        }

        private void function349()
        {
            throw new NotImplementedException();
        }

        private void function341()
        {
            throw new NotImplementedException();
        }

        private void function231()
        {
            throw new NotImplementedException();
        }

        private void function197()
        {
            throw new NotImplementedException();
        }

        private void function191()
        {
            throw new NotImplementedException();
        }

        private bool firePhasers() //Line 231
        {
            if (_enemyShips[_shipToAttack] == 1)
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
				|| !int.TryParse(commands[1], out _shipToAttack)
				|| !int.TryParse(commands[0], out _commandOption))
			{
				return false;
			}

			_commandOption = Math.Abs(_commandOption);
			_shipToAttack = Math.Abs(_shipToAttack);

			if(_commandOption > 16 || _shipToAttack > _numberOfAliens) //line 181 - 183
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
			switch (_commandOption) //Line 233
			{
				case 1:  //Line 235
                    if (_enemyDistance[_shipToAttack] > 300000 || _enemyDirection[_shipToAttack] > 180 || _hitsTaken >= 8)
                    {
						MoveImpossible();
						return;
                    }

					float N3 = 2 / _commandOption;
					P = P + N3;
					function975();
					break;
				case 2:
					function251();
					break;
				case 3:
					function257();
					break;
				case 4:
					function267();
					break;
				case 5:
					function273();
					break;
				case 6:
					function875();
					break;
				case 7:
					function913();
					break;
				case 8:
					function965();
					break;
				case 9:
					function961();
					break;
				case 10:
					function309();
					break;
				case 11:
					function333();
					break;

			}

			//TODO: Map remaining items
		}

        private void function333()
        {
            throw new NotImplementedException();
        }

        private void function267()
        {
            throw new NotImplementedException();
        }

        private void function273()
        {
            throw new NotImplementedException();
        }

        private void function875()
        {
            throw new NotImplementedException();
        }

        private void function913()
        {
            throw new NotImplementedException();
        }

        private void function965()
        {
            throw new NotImplementedException();
        }

        private void function961()
        {
            throw new NotImplementedException();
        }

        private void function309()
        {
            throw new NotImplementedException();
        }

        private void function257()
        {
            throw new NotImplementedException();
        }

        private void function251()
        {
            throw new NotImplementedException();
        }

        private void PowerToWeapons()
        {
			WriteLine("POWER DIVERTED TO WEAPONS", 1);
		}

		private void PowerToRepairs()
        {
			WriteLine("POWER DIVERTED TO REPAIRS", 1);
		}

		private void function377()
        {
			if (CINT == 1)
            {
				WriteLine(_cloakActivated);
			} 
	
			function381();
		}

		private void function381()
        {
			if(P3 == 2.5)
            {
				PowerToWeapons();
            }

			if(P3 == .5)
            {
				PowerToRepairs();
            }

			PromptForUserInput(); //Line 165

			function975();  
			//function537();  
		}

		private void SecondaryCircuitOverload()
		{
			WriteLine("SECONDARY DILITHIUM CIRCUIT FUSED");
			WriteLine("IMPLUSE POWER ONLY - LIMIT 2 MILLION STROMS");
			WriteLine("WARNING - IF CAPACITY OF IMPULSE ENGINE EXCEEDED IT ");
			WriteLine("WILL EXPLODE ", 1);

			C1 = 2; // LINE 433

			Function443();
		}

		private void PrimaryCircuitOverload() //Line 437
		{
			WriteLine("PRIMARY DILITHIUM CIRCUIT FUSED, SWITCHING TO SECONDARY");
			WriteLine("OVERLOAD CAPACITY FOR THIS CIRCUIT IS 10 MILLION STROMS", 1);
			C1 = 1; // LINE 441

			Function443();
		}

		private void Function443()
        {
			P = 0;

            switch (_commandOption)
            {
				case 5:
                    B1--;
                    break;
				case 3:
                    RINT = RINT - N2;
                    break;
				default:
					FInt = FInt - N2;
					break;
            }

			PromptForUserInput();
		}

		private void function537()
		{
			if(_hitsTaken >= 9)
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
				Z1 = _hitsTaken - .5f;

				if (Z1 > -1)//Line553
				{
					_hitsTaken = -1;
                }
                else
                {
					_hitsTaken = -1;
					//Line 561
                }

				EvaluateHitsTaken();
			}

			function605();
        }

		private void EvaluateHitsTaken()
        {
            switch (_hitsTaken)
            {
				case 9.5f:
                    if (C1 != 2)
                    {
                        WriteLine(String.Format("{0} WARP ENGINES REPAIRED", eng), 1);                 
                    }
                    break;
				case 8.5f:
                    if (FInt < 20 || RINT < 10) {
						WriteLine(String.Format("{0} {1} PROJECTORS REPAIRED", eng,pt), 1);
					}

					if (RINT >= 10)
					{
						WriteLine(String.Format("{0} NORMAL POWERS LEVELS RESTORED", eng), 1);
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

		private void FurtherRepairsImpossibe()
        {
            if (DInt < 4 || DInt > 9)
			{
				return;
			}

			DInt = 10;
			WriteLine(String.Format("{0} FURTHER REPAIRS IMPOSSIBLE" , eng));
		}

        private void function605()
        {
			for (int alien = 1; alien <= _numberOfAliens; alien++)
			{
				if (_enemyShips[alien] == 1)
				{
                    D1 = +1;
                    FurtherRepairsImpossibe();
					continue;
				}

				if (CINT != 0)
				{
                    if (_commandOption == 0)
                    {
                        WriteLine(String.Format("{0} {1} DOING NOTHING", alienName, alien));
                        continue;
                    }

                    if (H[alien] > 5 || F[alien] > 2)
                    {
                        AttemptToBreakContact(alien);

                        if (_enemyDistance[alien] < Math.Pow(10, 6))
                        {
                            FurtherRepairsImpossibe();
                            continue;
                        }

                        WriteLine(String.Format("{0} {1} OUT OF SENSOR RANGE- CONTACT BROKEN", alienName, alien));
                        _enemyShips[alien] = D[alien] = 1;

                        FurtherRepairsImpossibe();
                        continue;

                    }
                }

				DetermineAlienAction(alien);
			}
		}

        private void DetermineAlienAction(int alien)
        {
            if (_enemyDistance[alien] <= 500000)
            {
				DetermineAlienAction10K(alien);
            }

            if (H[alien] < 7)
            {
                if (H[alien] < 6)
                {
                    AlienApproaching(alien);
                    return;
                }
            }
        }

        private void DetermineAlienAction10K(int alien)
        {
            if (_enemyDistance[alien] >= 100000)
            {
                DetermineAlienAction20Gtr6K(alien);
				return;
			}

            if (H[alien] >= 7)
            {
                AttemptToBreakContact(alien);
                return;
            }
        }

        private void DetermineAlienAction20Gtr6K(int alien)
        {
            if (_enemyDistance[alien] >= 20000)
            {
				DetermineAlienAction30K(alien);

                if (H[alien] > 6)
                {
                    AttemptToBreakContact(alien);
                    return;
                }
            }
        }

        private void DetermineAlienAction30K(int alien)
        {
            if (_enemyDistance[alien] >= 30000)
            {
				DetermineAlienAction20K(alien);
				return;
            }

			Function669(alien);
        }

        private void DetermineAlienAction20K(int alien)
        {
            if (_enemyDistance[alien] >= 20000)
            {
                if (H[alien] < 6)
                {
                    AlienApproaching(alien);
                    return;
                }

            }

            if (_enemyPhotonTorpedos[alien] < 10)
            {
				//TODO: Need to break loop if ship destoryed
				AlienFireTorepedos(alien);

            }
        }

        private bool AlienFireTorepedos(int alien)
        {
			bool shipDestroyed = false;


			return shipDestroyed;
        }

        private void Function669(int alien)
        {
            if (H[alien] < 6)
            {
                if (_numberOfAliens > 2)
                {
                    if (AlienFiresPhasers(alien)) break;
                    return;
                }

                if (new Random().NextDouble() < .7)
                {
                    if (B2 == 10 || _enemyDistance[alien] < 100000)
                    {
                        if (AlienFiresPhasers(alien)) break;
                    }

                    B2 = B2 + 1;

                    if (B2 == 10)
                    {
                        WriteLine(String.Format("{0} {1} LAUNCHES ITS LAST {2}", alienName, alien, hepb));
                    }
                    else
                    {
                        WriteLine(String.Format("{0} {1} LAUNCHES {2}", alienName, alien, hepb));
                    }

                    //TODO: LINE 691 CODE TO CALCULATE DAMAGE
                    Function691(alien);
                    return;
                }
            }
        }

        private void Function691(int alien)
        {
			double B = new Random().NextDouble();

			if(B > 0.7 + CINT * 0.3)
            {
				H1 = H1 + 1;
                WriteLine("HIT ON THE USS ENTERPRISE", 0);
                H1 = H1 + 1;
                //TODO: LINE 833
            }

            if (B > 0.7 + CINT * 0.4)
            {
                H1 = H1 + 2;
                WriteLine("DIRECT HIT ON THE USS ENTERPRISE", 0);
                H1 = H1 + 2;
				//TODO: LINE 833
            }

			//TODO: Line 811
        }

        private bool AlienFiresPhasers(int alien)
        {
            //TODO: Need to break loop if ship destoryed
            WriteLine(String.Format("{0} {1} FIRES PHASERS AT ENTERPRISE", alienName, alien));

            if (!AlienEngagment()) 
            {
				return true;  //desttroyed enterpise need to signal back to stop battle
            }

			return false;
        }

        private void AlienApproaching(int alien)
        {
            _enemyDistance[alien] = _enemyDistance[alien] / 2;
            WriteLine(String.Format("{0} {1} APPROACHING", alienName, alien));
            PrintEnemyRange();
            FurtherRepairsImpossibe();
        }

        private void AttemptToBreakContact(int alien)
        {
            if (H[alien] >= 7)
            {
                _enemyDistance[alien] = _enemyDistance[alien] + 100000 + (int)(new Random().NextDouble() * 50000);
            }
            else
            {
                _enemyDistance[alien] = _enemyDistance[alien] + 200000 + (int)(new Random().NextDouble() * 100000);
            }

            WriteLine(String.Format("{0} {1} ATTEMPTING TO BREAK CONTACT", alienName, alien));
        }

        private bool AlienEngagment()
        {
			Double B = new Random().NextDouble();

			if (B > .3)
			{
				if (_commandOption > 0)
				{
					WriteLine("YOU OUTMANEUVERED ATTACKER, MISS");
					FurtherRepairsImpossibe();
					return true;
				}
				else
				{
					WriteLine("NEAR MISS");
					FurtherRepairsImpossibe();
					return true;
				}
			}
			else
			{
				WriteLine("HIT TAKEN ON ENTERPRISE");
				_hitsTaken = _hitsTaken + 1;

				if (ShipDestroyed())
				{
					PrintBattleResults();
					return false;
				}
			}

			return true;
		}

        private void function719(int shipNumber)
        {
			WriteLine(String.Format("{0} {1} FIRES ITS LAST {2}", alienName, shipNumber, pb));
		}

        private void function637(int shipNumber)
        {
			if (H[shipNumber] < 6)
			{
				_enemyDistance[shipNumber] = _enemyDistance[shipNumber] / 2;
				WriteLine(String.Format("{0} {1} APPROACHING", alienName, shipNumber));
				FurtherRepairsImpossibe();
				return;
			}

			if (_enemyPhotonTorpedos[shipNumber] == 10)
			{
				function719(shipNumber);
				return;
			}

			_enemyDistance[shipNumber] = _enemyDistance[shipNumber] / 2;
			WriteLine(String.Format("{0} {1} APPROACHING", alienName, shipNumber));
			FurtherRepairsImpossibe();
			return;
		}

        private bool ShipDestroyed()
        {
            if(_hitsTaken >= 11)
            {
				WriteLine("USS ENTERPRISE DESTROYED");
				D2 = 1;
				return true;
			}
            else if (_hitsTaken < 5 )
            {
				WriteLine("SHIELDS HOLDING, NO DAMAGE");
				FurtherRepairsImpossibe();
			}

            switch (_hitsTaken - 4)
            {
				case 1:
				case 2:
					function847();
					break;
				case 3:
					function851();
					break;
				case 4:
					function855();
					break;
				case 5:
					function859();
					break;
				case 6:
					function865();
					break;
				case 7:
					function869();
					break;
            }

			return false;
        }

        private void function869()
        {
			WriteLine("USS ENTERPRISE DESTROYED");
			D2 = 1;
			PrintBattleResults();
		}

        private void function865()
        {
			WriteLine("WARP POWER OFFLINE");
			function859();
		}

        private void function859()
        {
			WriteLine("WEAPONS AND SHIELDS DEACTIVATED");
			WriteLine("SHIPS POWER DROPPING" ,1);
			FurtherRepairsImpossibe();
		}

        private void function855()
        {
			WriteLine(String.Format("{0) DEACTIVATED ", pb));
			function851();
		}

        private void function851()
        {
			WriteLine("SHIELDS OFFLINE",	1);
		}

        private void function847()
        {
			WriteLine("SHIELDS WEAKENING",1);
		}

        private void function975()
        {
			if(CINT == 1)
            {
				P = P + 3;
            }


            if (P <= 20)// Line 979
            {
                if (P <= 10)
                {
					if(P<= 2)
                    {
						function537();
                    }
                }
				return;
			}

            if (C1 == 1)
            {
                SecondaryCircuitOverload();
            }

            if (C1 == 0)
            {
                PrimaryCircuitOverload();
                return;
            }

            if (C1 == 2) {
				ImpluseOverload();
			}
            
        }

        private void ImpluseOverload() //Line 909
        {
			WriteLine("IMPULSE ENGINE OVERLOAD", 1);

			CalculateBlastRadius();
		}

        private void CalculateBlastRadius()
        {
			R1 = 9800 * new Random().Next() + 200;
			WriteLine(String.Format("RADIUS OF EXPLOSION = {0} KM", R1), 1);

			for(int i = 1; i < _numberOfAliens + 1; i++)
            {
                if (_enemyShips[i]==1 || _enemyDistance[i] > R1)
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

				_enemyShips[i] = 1;
            }

			D2 = 1;

			PrintBattleResults();
		}

        private void PrintBattleResults()  //Line993
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
			char[] chars = text.ToCharArray();

			foreach(char c in chars)
            {
				Console.Write(c);
				Thread.Sleep(100);
            }

			Console.Write("\n");
			//Console.WriteLine(text);

			for(int i = 0; i < blankLinesAfter; i++)
            {
				Console.WriteLine(" ");
            }
        }
	}
}

