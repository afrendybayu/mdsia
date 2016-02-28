using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

struct T1_3 {
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public UInt16 status;
	public UInt16 turn;
}

namespace hello
{
	class AISVDM	{

		public static void Main (string[] args)		{
			string ais = "aaaaaaaaaabc!AIVDM,1,1,,B,139eb:PP00PIHDNMdd6@0?vN2D2s,0*43";

			string six_bit = cariAIVM (ais);
			string sBit = SixBitBiner (six_bit);

			ParsingT1_3 (sBit);
		}

		static int ParsingT1_3(string sBit) {
			//Console.WriteLine ("sBit: {0}", sBit);
			T1_3 stt = new T1_3();

			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.status = Convert.ToUInt16(bin2int(sBit.Substring (38, 4)));
			stt.turn = Convert.ToUInt16(bin2int(sBit.Substring (42, 8)));

			Console.WriteLine ("tipe: {0}", stt.type);
			Console.WriteLine ("rept: {0}", stt.repeat);
			Console.WriteLine ("mmsi: {0} ", stt.mmsi);
			Console.WriteLine ("stat: {0}", stt.status);
			Console.WriteLine ("turn: {0} ", stt.turn);

			return 1;
		}

		static int bin2int(string temp_s)	{
			int i=0;
			for (int x=0; x<temp_s.Length; x++) {
				i=i + ((temp_s[x]-48) * (1<<(temp_s.Length-x-1)));
				//cout<<"b2i "<<temp_s[x] <<" "<<(1<<(temp_s.length()-x-1))<<" "<< ((temp_s[x]-48) * (1<<(temp_s.length()-x-1)))<<endl;
			}
			return i;
		}

		static string cariAIVM(string ais) {
			int x,st=0;
			// find !AIVMD or !AIVDO
			for (x=0; x<ais.Length; x++) {
				if (ais.Substring(x,5) == "!AIVD") {
					st=x;
					break;
				}
			}

			string ais_str = ais.Substring (st, ais.Length - st);
			Console.WriteLine(ais_str);

			int y=0,ais_s=0,ais_f=0;
			for (x=0; x<ais_str.Length; x++) {
				if(ais_str.Substring(x,1)==",") {
					y++;
					if(y==5) ais_s=x+1;
					if(y==6) ais_f=x-1;
				}
			}
			//string six_bit=ais_str.Substring(ais_s,ais_f-ais_s+1);
			return (ais_str.Substring(ais_s,ais_f-ais_s+1));
		}

		static string SixBitBiner(string sixbit)	{
			// six bit ascii table. (gpsd.berlios.de/AIVDM)
			string[] six_bit_table = new string[120];
			six_bit_table[48]="000000";
			six_bit_table[49]="000001";
			six_bit_table[50]="000010";
			six_bit_table[51]="000011";
			six_bit_table[52]="000100";
			six_bit_table[53]="000101";
			six_bit_table[54]="000110";
			six_bit_table[55]="000111";
			six_bit_table[56]="001000";
			six_bit_table[57]="001001";
			six_bit_table[58]="001010";
			six_bit_table[59]="001011";
			six_bit_table[60]="001100";
			six_bit_table[61]="001101";
			six_bit_table[62]="001110";
			six_bit_table[63]="001111";
			six_bit_table[64]="010000";
			six_bit_table[65]="010001";
			six_bit_table[66]="010010";
			six_bit_table[67]="010011";
			six_bit_table[68]="010100";
			six_bit_table[69]="010101";
			six_bit_table[70]="010110";
			six_bit_table[71]="010111";
			six_bit_table[72]="011000";
			six_bit_table[73]="011001";
			six_bit_table[74]="011010";
			six_bit_table[75]="011011";
			six_bit_table[76]="011100";
			six_bit_table[77]="011101";
			six_bit_table[78]="011110";
			six_bit_table[79]="011111";
			six_bit_table[80]="100000";
			six_bit_table[81]="100001";
			six_bit_table[82]="100010";
			six_bit_table[83]="100011";
			six_bit_table[84]="100100";
			six_bit_table[85]="100101";
			six_bit_table[86]="100110";
			six_bit_table[87]="100111";

			six_bit_table[96]="101000";
			six_bit_table[97]="101001";
			six_bit_table[98]="101010";
			six_bit_table[99]="101011";
			six_bit_table[100]="101100";
			six_bit_table[101]="101101";
			six_bit_table[102]="101110";
			six_bit_table[103]="101111";
			six_bit_table[104]="110000";
			six_bit_table[105]="110001";
			six_bit_table[106]="110010";
			six_bit_table[107]="110011";
			six_bit_table[108]="110100";
			six_bit_table[109]="110101";
			six_bit_table[110]="110110";
			six_bit_table[111]="110111";
			six_bit_table[112]="111000";
			six_bit_table[113]="111001";
			six_bit_table[114]="111010";
			six_bit_table[115]="111011";
			six_bit_table[116]="111100";
			six_bit_table[117]="111101";
			six_bit_table[118]="111110";
			six_bit_table[119]="111111";

			//Console.WriteLine(sixbit);

			string ais_bin="";
			int z,x, y;

			for (x=0; x<sixbit.Length; x++) {
				z=sixbit[x];
				y=(x+1)*6-5;
				//Console.WriteLine(six_bit_table[z]);
				ais_bin += six_bit_table [z];
			}

			//Console.WriteLine(ais_bin);
			return ais_bin;
		}
	}
}
