using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

struct T5 {
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public UInt16 ais_v;
	public UInt32 imo;
	public string callsign;
	public string vessel;
	public UInt16 shiptype;
	public float bow;
	public float stern;
	public float port;
	public float starboard;
	public float epfd;
	public UInt16 month;
	public UInt16 day;
	public UInt16 hour;
	public UInt16 minute;
	public float draught;
	public string dest;
	public bool dte;
}

struct T1_3 {
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public UInt16 status;
	public UInt16 turn;
	public float speed;
	public Boolean accuracy;
	public float lon;
	public float lat;
	public float course;
	public float heading;
	public UInt16 second;
	public float manuver;
	public Boolean raim;
	public UInt32 radio;
}

namespace hello
{
	class AISVDM	{

		public static void Main (string[] args)		{
			//string ais = "aaaaaaaaaabc!AIVDM,1,1,,B,139eb:PP00PIHDNMdd6@0?vN2D2s,0*43";
			//string ais = "!AIVDM,2,1,9,B,53nFBv01SJ<thHp6220H4heHTf2222222222221?50:454o<`9QSlUDp,0*09";
			//string ais = "!AIVDM,2,1,9,B,53nFBv01SJ<thHp6220H4heHTf2222222222221?50:454o<`9QSlUDp888888888888880,0*09";
			string ais = "!AIVDM,3,1,5,A,36KVnDh02wawaHPDA8T8h6tT8000t=AV=maD7?>BWiKIE@TR<2QfvaAF1ST4H31B,0*35";
//			string ais = "!AIVDM,2,1,6,B,56:fS:D0000000000008v0<QD4r0`T4v3400000t0`D147?ps1P00000000000000000008,0*3D";
//			

			string six_bit = cariAIVM (ais);
			string sBit = SixBitBiner (six_bit);

			int type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));

			switch (type) {
			case 1:
			case 2:
			case 3:
				//if (sBit.Length == 168)
					Console.WriteLine("Masuk ke Parsing T1_3");
					ParsingT1_3 (sBit);
				break;
			case 5:
				ParsingT5 (sBit);
				break;
			};

		}

		static T5 ParsingT5 (string sBit)	{
			Console.WriteLine ("len: {1}, sBit: {0}", sBit, sBit.Length);
			T5 stt = new T5();

			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.ais_v = Convert.ToUInt16(bin2int(sBit.Substring (38, 2)));
			stt.imo = Convert.ToUInt32(bin2int(sBit.Substring (40, 30)));
			stt.callsign = str6bit(sBit.Substring (70, 42));
			stt.vessel = str6bit(sBit.Substring (112, 120));
			stt.shiptype = Convert.ToUInt16(bin2int(sBit.Substring (232, 8)));
			stt.bow = Convert.ToUInt16(bin2int(sBit.Substring (240, 9)));
			stt.stern = Convert.ToUInt16(bin2int(sBit.Substring (249, 9)));
			stt.port = Convert.ToUInt16(bin2int(sBit.Substring (258, 6)));
			stt.starboard = Convert.ToUInt16(bin2int(sBit.Substring (264, 6)));
			stt.epfd = Convert.ToUInt16(bin2int(sBit.Substring (270, 4)));
			stt.month = Convert.ToUInt16(bin2int(sBit.Substring (274, 4)));
			stt.day = Convert.ToUInt16(bin2int(sBit.Substring (278, 5)));
			stt.hour = Convert.ToUInt16(bin2int(sBit.Substring (283, 5)));
			stt.minute = Convert.ToUInt16(bin2int(sBit.Substring (288, 6)));
			stt.draught = (float) ((bin2int(sBit.Substring (294, 8)))/10.0);
			stt.dest = str6bit(sBit.Substring (302, 120));
			stt.dte = Convert.ToBoolean(bin2int(sBit.Substring (422, 1)));

			Console.WriteLine ("tip: {0}", stt.type);
			Console.WriteLine ("rep: {0}", stt.repeat);
			Console.WriteLine ("mms: {0} ", stt.mmsi);
			Console.WriteLine ("ais: {0}", stt.ais_v);
			Console.WriteLine ("imo: {0}", stt.imo);
			Console.WriteLine ("cls: {0}", stt.callsign);
			Console.WriteLine ("vsl: {0}", stt.vessel);
			Console.WriteLine ("sty: {0}", stt.shiptype);
			Console.WriteLine ("bow: {0}", stt.bow);
			Console.WriteLine ("ste: {0}", stt.stern);
			Console.WriteLine ("por: {0}", stt.port);
			Console.WriteLine ("stb: {0}", stt.starboard);
			Console.WriteLine ("epf: {0}", stt.epfd);
			Console.WriteLine ("mon: {0}", stt.month);
			Console.WriteLine ("mon: {0}", stt.month);
			Console.WriteLine ("day: {0}", stt.day);
			Console.WriteLine ("hou: {0}", stt.hour);
			Console.WriteLine ("min: {0}", stt.minute);
			Console.WriteLine ("dra: {0}", stt.draught);
			Console.WriteLine ("des: {0}", stt.dest);
			Console.WriteLine ("dte: {0}", stt.dte);

			return stt;
		}

		static string str6bit(string str)	{
			int x = 1,y=0, len = str.Length;
			UInt32 c;
			char[] ss = new char[32];

			while (x < len) {
				c = Convert.ToUInt32 (bin2int (str.Substring (x-1, 6)));
				if (c>=32)
					c += 0;
				else if (c==0)
					c += 0;
				else {
					c += 64;
				}
				
				//Console.WriteLine("{0} {1} {2}", str.Substring (x-1,6), x, c);
				ss[++y] = (char) c;

				x += 6;

			}
			//Console.WriteLine ("{1}\r\n", ss);
			string s = new string(ss);
			Console.WriteLine(s);
			return s;
		}

		static T1_3 ParsingT1_3(string sBit) {
			Console.WriteLine ("len: {1}, sBit: {0}", sBit, sBit.Length);
			T1_3 stt = new T1_3();

			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.status = Convert.ToUInt16(bin2int(sBit.Substring (38, 4)));
			stt.turn = Convert.ToUInt16(bin2int(sBit.Substring (42, 8)));
			stt.speed = (bin2int(sBit.Substring (50, 10)))/10;
			stt.accuracy = Convert.ToBoolean(bin2int(sBit.Substring (60, 1)));

			bool west = Convert.ToBoolean(bin2int(sBit.Substring (61, 1)));
			UInt32 lon = Convert.ToUInt32(bin2int(sBit.Substring (61, 28)));
			stt.lon = getPos (lon, west);

			/*
			if (west) {
				lon = ~lon;
			}

			stt.lon = (float) (lon*1.0/10000/60);
			if (west) {
				stt.lon *= -1;
			}
			//*/

			bool south = Convert.ToBoolean(bin2int(sBit.Substring (89, 1)));
			UInt32 lat = Convert.ToUInt32(bin2int(sBit.Substring (89, 27)));

			stt.lat = getPos(lat, south);
			/*
			if (south) {
				lat = ~lat;
			}

			stt.lat = (float) (lat*1.0/10000/60);
			if (south) {
				stt.lat *= -1;
			}
			//*/

			stt.course = (bin2int(sBit.Substring (116, 12)))/10;
			stt.heading = Convert.ToUInt32(bin2int(sBit.Substring (128, 9)));
			stt.second = Convert.ToUInt16(bin2int(sBit.Substring (137, 6)));
			stt.manuver = Convert.ToUInt16(bin2int(sBit.Substring (143, 2)));
			stt.raim = Convert.ToBoolean(bin2int(sBit.Substring (148, 1)));

			//Console.WriteLine ("radio: {0}", bin2int(sBit.Substring (149)));
			stt.radio = Convert.ToUInt32(bin2int(sBit.Substring (149,19)));

			Console.WriteLine ("tip: {0}", stt.type);
			Console.WriteLine ("rep: {0}", stt.repeat);
			Console.WriteLine ("mms: {0} ", stt.mmsi);
			Console.WriteLine ("sta: {0}", stt.status);
			Console.WriteLine ("tur: {0} ", stt.turn);
			Console.WriteLine ("spe: {0} ", stt.speed);
			Console.WriteLine ("acc: {0} ", stt.accuracy);
			Console.WriteLine ("lon: {0} ", stt.lon);
			Console.WriteLine ("lat: {0} ", stt.lat);
			Console.WriteLine ("cou: {0} ", stt.course);
			Console.WriteLine ("hea: {0} ", stt.heading);
			Console.WriteLine ("sec: {0} ", stt.second);
			Console.WriteLine ("man: {0} ", stt.manuver);
			Console.WriteLine ("rai: {0} ", stt.raim);
			Console.WriteLine ("rad: {0} ", stt.radio);

			return stt;
		}

		static float getPos(UInt32 num, bool one) {
			UInt32 x = num;
			if (one) {
				x = ~x;
			}

			float f = (float) (x*1.0/10000/60);
			if (one) {
				f *= -1;
			}
			return f;
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
