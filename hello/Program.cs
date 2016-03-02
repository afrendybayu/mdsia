
#define DISP_DEBUG

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

struct T4 {
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public UInt16 year;
	public UInt16 month;
	public UInt16 day;
	public UInt16 hour;
	public UInt16 minute;
	public UInt16 second;
	public Boolean accuracy;
	public float lon;
	public float lat;
	public UInt16 epfd;
	public Boolean raim;
	public UInt32 radio;
}

struct T5 {				//
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
	public UInt16 epfd;
	public UInt16 month;
	public UInt16 day;
	public UInt16 hour;
	public UInt16 minute;
	public float draught;
	public string dest;
	public bool dte;
}

struct T6 {				// Addressed Message
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi_s;
	public UInt16 seqno;
	public UInt32 mmsi_d;
	public bool retransmit;
	public UInt16 dac;
	public UInt16 fid;
	//public float df [25];
	//public int di [25];
	//public char dc [115];
	public int ndata;
	public UInt16 tipeD;
}

struct T8 {				// Broaadcast
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public UInt16 dac;
	public UInt16 fid;
	//public float df[28];
	//public int di[28];
	//public char dc[120];
	public int ndata;
	public UInt16 tipeD;
}

struct T18 {			// 1 sequent
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public float speed;
	public Boolean accuracy;
	public float lon;
	public float lat;
	public float course;
	public UInt16 heading;
	public UInt16 second;
	public UInt16 regional;
	public Boolean cs;
	public Boolean display;
	public Boolean dsc;
	public Boolean band;
	public Boolean msg22;
	public Boolean assign;
	public Boolean raim;
	public UInt32 radio;
}

struct T19 {			// 1 sequent
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public float speed;
	public Boolean accuracy;
	public float lon;
	public float lat;
	public float course;
	public UInt16 heading;
	public UInt16 second;
	public UInt16 regional;
	public string vessel;
	public UInt16 shiptype;
	public UInt16 bow;
	public UInt16 stern;
	public UInt16 port;
	public UInt16 starboard;
	public UInt16 epfd;
	public Boolean raim;
	public Boolean dte;
	public UInt16 assign;
}

struct T24 {
	public UInt16 type;
	public UInt16 repeat;
	public UInt32 mmsi;
	public UInt16 partno;
	public string vessel_a;
	public UInt16 shiptype_b;
	public string vendorid_b;
	public UInt16 model_b;
	public UInt32 serial_b;
	public string callsign_b;
	public UInt16 bow_b;
	public UInt16 stern_b;
	public UInt16 port_b;
	public UInt16 starboard_b;
	public UInt32 m_mmsi_b;
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

namespace hello	 {
	class AISVDM	{

		public static void Main (string[] args)		{
			//string ais = "aaaaaaaaaabc!AIVDM,1,1,,B,139eb:PP00PIHDNMdd6@0?vN2D2s,0*43";
			//string ais = "!AIVDM,1,1,,A,13aBNBg000PC`SdMHsm8oJl2P0SR,0*21";
//			string ais = "!AIVDM,1,1,,B,13aJINPP00PCnVbMFFuq;wvR2H9v,0*56";
//			string ais = "!AIVDM,1,1,,B,13bj?d00240FQsJNmjchCh<00@Rr,0*59";
//			string ais = "!AIVDM,1,1,,B,13aEOU@P1q0D7i0MdRSb0gvPR89v,0*4D";
//			string ais = "!AIVDM,1,1,,A,13fCIn001w0KB<tNe6J2oB:00@S7,0*47";
//			string ais = "!AIVDM,1,1,,A,13a5Rb9000PLI<dNV5g;fWn405Ip,0*62";
//			string ais = "!AIVDM,1,1,,A,33tssF0shiPn=DrQ0KMRgB6P20u1,0*53";
//			string ais = "!AIVDM,1,1,,A,13aDrg`P12PLDFjNMNRQtOv4281`,0*3F";
			//string ais = "!AIVDM,1,1,,A,13u?etPv2;0n:dDPwUM1U1Cb069D,0*24";
			//string ais = "!AIVDM,2,1,9,B,53nFBv01SJ<thHp6220H4heHTf2222222222221?50:454o<`9QSlUDp,0*09";
			//string ais = "!AIVDM,2,1,9,B,53nFBv01SJ<thHp6220H4heHTf2222222222221?50:454o<`9QSlUDp888888888888880,0*09";
			//string ais = "!AIVDM,3,1,5,A,36KVnDh02wawaHPDA8T8h6tT8000t=AV=maD7?>BWiKIE@TR<2QfvaAF1ST4H31B,0*35";
//			string ais = "!AIVDM,2,1,6,B,56:fS:D0000000000008v0<QD4r0`T4v3400000t0`D147?ps1P00000000000000000008,0*3D";
			//string ais = "!AIVDM,2,1,1,A,53m66:000000h4l4000e>0pu8LD000000000001J3hj<04000<Slk3h0000000000000003,0*5E";
			//string ais = "!AIVDM,1,1,,A,B1P2Wk@0G27Kp?3PDg<fcwlW1P06,0*6F";
			//string ais = "!AIVDM,1,1,,B,4025;PAuho;N>0NJbfMRhNA00D3l,0*66";
			//string ais = "!AIVDM,1,1,,B,H>DQ@04N6DeihhlPPPPPPP000000,0*0E";
			//string ais = "!AIVDM,1,1,,A,H7P<1>4UB1I0000F=Aqpoo2P2220,0*3A";
			//string ais = "!AIVDM,1,1,,B,177KQJ5000G?tO`K>RA1wUbN0TKH,0*5C";
			string ais = "!AIVDM,2,1,0,B,C8u:8C@t7@TnGCKfm6Po`e6N`:Va0L2J;06HV50JV?SjBPL311RP,0*28";

			/*
			float f = (float) (-29.83748);
			posDeg (f, true);
			return;
			//*/

			string ais_fix = cariAIVM (ais);

			/*
			if (!cek_cs (ais_fix)) {
				Console.WriteLine ("CHECKSUM BEDA !!");
				return;
			}
			//*/

			Console.WriteLine ("ais_fix: {0}", ais_fix);
			string six_bit = cariPayloadAis (ais_fix);

			Console.WriteLine ();
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
			case 4:
					Console.WriteLine("Masuk ke Parsing T4");
					ParsingT4 (sBit);
				break;
			case 5:
				Console.WriteLine("Masuk ke Parsing T5");
					ParsingT5 (sBit);
				break;
			case 18:
					Console.WriteLine("Masuk ke Parsing T18");
					ParsingT18 (sBit);
				break;
			case 19:
				Console.WriteLine("Masuk ke Parsing T19");
				ParsingT19 (sBit);
				break;
			case 24:
					Console.WriteLine("Masuk ke Parsing T24");
					ParsingT24 (sBit);
				break;
			};

		}

		static bool cek_cs(string ais)	{
			string cs = ais.Substring (ais.Length - 2);
			string pl = ais.Substring (1, ais.Length - 4);
			//Console.WriteLine ("cs: {0} {1}", cs, bin2int(cs));
			//Console.WriteLine ("pl: {0}", pl);

			UInt16 check = 0;
			for (int c = 0; c < pl.Length; c++) {
				check ^= Convert.ToChar(pl[c]);
				//Console.WriteLine ("cs: {0}", check);
			}
			//Console.WriteLine ("akhir: {0:X} {1} {2}", check, Convert.ToInt32(cs, 16), check.ToString());

			if (Convert.ToInt16 (cs, 16) == check) {
				//Console.WriteLine ("checksum SAMA");
				return true;
			}
			else
				return false;
		}

		static string posDeg(float pos, bool west ) {
			//Console.WriteLine ("pos: {0}, arah: {1}", pos, west);
			UInt16 deg=0, men=0;
			float t, det=0;
			String p = "";

			deg = (UInt16) (Math.Abs (pos));
			if (pos>0)
				t = (float) ((pos - deg)*60.0);
			else
				t = (float) (Math.Abs(pos + deg)*60.0);
			
			men = (UInt16) t;

			if (pos>0 && west)		p = "E";
			if (pos>0 && !west)		p = "N";
			if (pos<=0 && west)		p = "W";
			if (pos<=0 && !west)	p = "S";

			det = (float) ((t-men)*60.0);
			String aa = String.Format (": {0}{3} {1}\' {2}\"", deg, men, det, p);
			//Console.WriteLine (p);
			return aa;
		}

		static T18 ParsingT18 (string sBit)	{
			T18 stt = new T18();

			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.speed = (float)((bin2int(sBit.Substring (46, 10)))*1.0/10);
			stt.accuracy = Convert.ToBoolean(bin2int(sBit.Substring (56, 1)));

			bool west = Convert.ToBoolean(bin2int(sBit.Substring (57, 1)));
			UInt32 lon = Convert.ToUInt32(bin2int(sBit.Substring (57, 28)));
			stt.lon = getPos (lon, west, true);

			bool south = Convert.ToBoolean(bin2int(sBit.Substring (85, 1)));
			UInt32 lat = Convert.ToUInt32(bin2int(sBit.Substring (85, 27)));
			stt.lat = getPos(lat, south, false);

			stt.course = (bin2int(sBit.Substring (112, 12)))/10;
			stt.heading = Convert.ToUInt16(bin2int(sBit.Substring (124, 9)));
			stt.second = Convert.ToUInt16(bin2int(sBit.Substring (133, 6)));
			stt.regional = Convert.ToUInt16(bin2int(sBit.Substring (139, 2)));

			stt.cs = Convert.ToBoolean(bin2int(sBit.Substring (141, 1)));
			stt.display = Convert.ToBoolean(bin2int(sBit.Substring (142, 1)));
			stt.dsc = Convert.ToBoolean(bin2int(sBit.Substring (143, 1)));
			stt.band = Convert.ToBoolean(bin2int(sBit.Substring (144, 1)));
			stt.msg22 = Convert.ToBoolean(bin2int(sBit.Substring (145, 1)));
			stt.assign = Convert.ToBoolean(bin2int(sBit.Substring (146, 1)));

			stt.raim = Convert.ToBoolean(bin2int(sBit.Substring (147, 1)));
			stt.radio = Convert.ToUInt32(bin2int(sBit.Substring (148,19)));

			#if DISP_DEBUG
			Console.WriteLine ("tip: {0}", stt.type);
			Console.WriteLine ("rep: {0}", stt.repeat);
			Console.WriteLine ("mms: {0} ", stt.mmsi);
			Console.WriteLine ("spe: {0} ", stt.speed);
			Console.WriteLine ("acc: {0} ", stt.accuracy);
			Console.WriteLine ("lon: {0} ", stt.lon);
			Console.WriteLine ("lat: {0} ", stt.lat);
			Console.WriteLine ("cou: {0} ", stt.course);
			Console.WriteLine ("hea: {0} ", stt.heading);
			Console.WriteLine ("sec: {0} ", stt.second);
			Console.WriteLine ("reg: {0} ", stt.regional);

			Console.WriteLine ("csu: {0} ", stt.cs);
			Console.WriteLine ("dis: {0} ", stt.display);
			Console.WriteLine ("dsc: {0} ", stt.dsc);
			Console.WriteLine ("ban: {0} ", stt.band);
			Console.WriteLine ("msg: {0} ", stt.msg22);
			Console.WriteLine ("ass: {0} ", stt.assign);

			Console.WriteLine ("rai: {0} ", stt.raim);
			Console.WriteLine ("rad: {0} ", stt.radio);
			#endif

			return stt;
		}

		static T19 ParsingT19 (string sBit)	{
			T19 stt = new T19();
			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.speed = (float)((bin2int(sBit.Substring (46, 10)))*1.0/10);
			stt.accuracy = Convert.ToBoolean(bin2int(sBit.Substring (56, 1)));

			bool west = Convert.ToBoolean(bin2int(sBit.Substring (57, 1)));
			UInt32 lon = Convert.ToUInt32(bin2int(sBit.Substring (57, 28)));
			stt.lon = getPos (lon, west, true);

			bool south = Convert.ToBoolean(bin2int(sBit.Substring (85, 1)));
			UInt32 lat = Convert.ToUInt32(bin2int(sBit.Substring (85, 27)));
			stt.lat = getPos(lat, south, false);

			stt.course = (bin2int(sBit.Substring (112, 12)))/10;
			stt.heading = Convert.ToUInt16(bin2int(sBit.Substring (124, 9)));
			stt.second = Convert.ToUInt16(bin2int(sBit.Substring (133, 6)));
			stt.regional = Convert.ToUInt16(bin2int(sBit.Substring (139, 4)));

			stt.vessel = str6bit(sBit.Substring (143, 120));
			stt.shiptype = Convert.ToUInt16(bin2int(sBit.Substring (263, 8)));
			stt.bow = Convert.ToUInt16(bin2int(sBit.Substring (271, 9)));
			stt.stern = Convert.ToUInt16(bin2int(sBit.Substring (280, 9)));
			stt.port = Convert.ToUInt16(bin2int(sBit.Substring (289, 6)));
			stt.starboard = Convert.ToUInt16(bin2int(sBit.Substring (295, 6)));
			stt.epfd = Convert.ToUInt16(bin2int(sBit.Substring (301, 4)));

			stt.raim = Convert.ToBoolean(bin2int(sBit.Substring (305, 1)));
			stt.dte = Convert.ToBoolean(bin2int(sBit.Substring (306,1)));
			stt.assign = Convert.ToUInt16(bin2int(sBit.Substring (307, 4)));

			#if DISP_DEBUG
			Console.WriteLine ("tip: {0}", stt.type);
			Console.WriteLine ("rep: {0}", stt.repeat);
			Console.WriteLine ("mms: {0} ", stt.mmsi);
			Console.WriteLine ("spe: {0} ", stt.speed);
			Console.WriteLine ("acc: {0} ", stt.accuracy);
			Console.WriteLine ("lon: {0} {1}", stt.lon, posDeg(stt.lon, true));
			Console.WriteLine ("lat: {0} {1}", stt.lat, posDeg(stt.lat, false));
			Console.WriteLine ("cou: {0} ", stt.course);
			Console.WriteLine ("hea: {0} ", stt.heading);
			Console.WriteLine ("sec: {0} ", stt.second);
			Console.WriteLine ("reg: {0} ", stt.regional);

			Console.WriteLine ("ves: {0} ", stt.vessel);
			Console.WriteLine ("sht: {0} ", stt.shiptype);
			Console.WriteLine ("bow: {0} ", stt.bow);
			Console.WriteLine ("ste: {0} ", stt.stern);
			Console.WriteLine ("por: {0} ", stt.port);
			Console.WriteLine ("sta: {0} ", stt.starboard);
			Console.WriteLine ("epf: {0} ", stt.epfd);

			Console.WriteLine ("rai: {0} ", stt.raim);
			Console.WriteLine ("dte: {0} ", stt.dte);
			Console.WriteLine ("ass: {0} ", stt.assign);
			#endif

			return stt;
		}

		static T24 ParsingT24(string sBit) {
			T24 stt = new T24 ();
			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.partno = Convert.ToUInt16(bin2int(sBit.Substring (38, 2)));

			if (stt.partno == 0) {
				stt.vessel_a = str6bit(sBit.Substring (40, 120));
			} else {
				stt.shiptype_b = Convert.ToUInt16(bin2int(sBit.Substring (40, 8)));
				stt.vendorid_b = str6bit(sBit.Substring (48, 18));
				stt.model_b = Convert.ToUInt16(bin2int(sBit.Substring (66, 4)));
				stt.serial_b = Convert.ToUInt32(bin2int(sBit.Substring (70, 20)));
				stt.callsign_b = str6bit(sBit.Substring (90, 42));
				stt.bow_b = Convert.ToUInt16(bin2int(sBit.Substring (132, 9)));
				stt.stern_b = Convert.ToUInt16(bin2int(sBit.Substring (141, 9)));
				stt.port_b = Convert.ToUInt16(bin2int(sBit.Substring (150, 6)));
				stt.starboard_b = Convert.ToUInt16(bin2int(sBit.Substring (156, 6)));
				stt.m_mmsi_b = Convert.ToUInt32(bin2int(sBit.Substring (132, 30)));
			}

			#if DISP_DEBUG
			Console.WriteLine ("tip: {0}", stt.type);
			Console.WriteLine ("rep: {0}", stt.repeat);
			Console.WriteLine ("mss: {0}", stt.mmsi);
			Console.WriteLine ("pno: {0}", stt.partno);

			if (stt.partno == 0)
				Console.WriteLine ("mon: {0}", stt.vessel_a);
			else {
				Console.WriteLine ("shp: {0}", stt.shiptype_b);
				Console.WriteLine ("ven: {0}", stt.vendorid_b);
				Console.WriteLine ("mod: {0}", stt.model_b);
				Console.WriteLine ("ser: {0}", stt.serial_b);
				Console.WriteLine ("cal: {0}", stt.callsign_b);
				Console.WriteLine ("bow: {0}", stt.bow_b);
				Console.WriteLine ("ste: {0}", stt.stern_b);
				Console.WriteLine ("por: {0}", stt.port_b);
				Console.WriteLine ("sta: {0}", stt.starboard_b);
				Console.WriteLine ("mmm: {0}", stt.m_mmsi_b);
			}
			#endif

			return stt;
		}

		static T4 ParsingT4 (string sBit)	{
			//Console.WriteLine ("len: {1}, sBit: {0}", sBit, sBit.Length);
			T4 stt = new T4();

			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));

			stt.year = Convert.ToUInt16(bin2int(sBit.Substring (38, 14)));
			stt.month = Convert.ToUInt16(bin2int(sBit.Substring (52, 4)));
			stt.day = Convert.ToUInt16(bin2int(sBit.Substring (56, 5)));
			stt.hour = Convert.ToUInt16(bin2int(sBit.Substring (61, 5)));
			stt.minute = Convert.ToUInt16(bin2int(sBit.Substring (66, 6)));
			stt.second = Convert.ToUInt16(bin2int(sBit.Substring (72, 6)));

			stt.accuracy = Convert.ToBoolean(bin2int(sBit.Substring (78, 1)));
			bool west = Convert.ToBoolean(bin2int(sBit.Substring (79, 1)));
			UInt32 lon = Convert.ToUInt32(bin2int(sBit.Substring (79, 28)));
			stt.lon = getPos (lon, west, true);

			bool south = Convert.ToBoolean(bin2int(sBit.Substring (107, 1)));
			UInt32 lat = Convert.ToUInt32(bin2int(sBit.Substring (107, 27)));
			stt.lat = getPos(lat, south, false);


			stt.epfd = Convert.ToUInt16(bin2int(sBit.Substring (134, 4)));
			stt.raim = Convert.ToBoolean(bin2int(sBit.Substring (148, 1)));
			stt.radio = Convert.ToUInt32(bin2int(sBit.Substring (149,19)));


			#if DISP_DEBUG
			Console.WriteLine ("tip: {0}", stt.type);
			Console.WriteLine ("rep: {0}", stt.repeat);
			Console.WriteLine ("mss: {0}", stt.mmsi);
			Console.WriteLine ("yea: {0}", stt.year);
			Console.WriteLine ("mon: {0}", stt.month);
			Console.WriteLine ("day: {0}", stt.day);
			Console.WriteLine ("hou: {0}", stt.hour);
			Console.WriteLine ("min: {0}", stt.minute);
			Console.WriteLine ("sec: {0}", stt.second);
			Console.WriteLine ("lon: {0}", stt.lon);
			Console.WriteLine ("lat: {0}", stt.lat);
			Console.WriteLine ("epf: {0}", stt.epfd);
			Console.WriteLine ("rai: {0}", stt.raim);
			Console.WriteLine ("rad: {0}", stt.radio);
			#endif

			return stt;
		}

		static T5 ParsingT5 (string sBit)	{
			//Console.WriteLine ("len: {1}, sBit: {0}", sBit, sBit.Length);
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

			#if DISP_DEBUG
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
			#endif

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

			string s = new string(ss);
			//Console.WriteLine(s);
			return s;
		}

		static T1_3 ParsingT1_3(string sBit) {
			//Console.WriteLine ("len: {1}, sBit: {0}", sBit, sBit.Length);
			T1_3 stt = new T1_3();

			stt.type = Convert.ToUInt16(bin2int(sBit.Substring (0, 6)));
			stt.repeat = Convert.ToUInt16(bin2int(sBit.Substring (6, 2)));
			stt.mmsi = Convert.ToUInt32(bin2int(sBit.Substring (8, 30)));
			stt.status = Convert.ToUInt16(bin2int(sBit.Substring (38, 4)));
			stt.turn = Convert.ToUInt16(bin2int(sBit.Substring (42, 8)));
			stt.speed = (float)((bin2int(sBit.Substring (50, 10)))*1.0/10);
			stt.accuracy = Convert.ToBoolean(bin2int(sBit.Substring (60, 1)));

			bool west = Convert.ToBoolean(bin2int(sBit.Substring (61, 1)));
			UInt32 lon = Convert.ToUInt32(bin2int(sBit.Substring (61, 28)));
			stt.lon = getPos (lon, west, true);

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

			stt.lat = getPos(lat, south, false);
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

			#if DISP_DEBUG
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
			#endif

			return stt;
		}

		static float getPos(UInt32 num, bool one, bool west) {
			UInt32 x = num;
			//Console.WriteLine ("num: {0:x8} {1} {2:x8}", num, one, ~num);

			if (one) {
				if (west)
					x = ~x & 0x7ffffff;
				else
					x = ~x & 0x3ffffff;
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
			int x, st = 0;
			// find !AIVMD or !AIVDO
			for (x = 0; x < ais.Length; x++) {
				if (ais.Substring (x, 5) == "!AIVD") {
					st = x;
					break;
				}
			}
			return (ais.Substring (st, ais.Length - st));
		}

		static string cariPayloadAis(string ais_str) {
			//string ais_str = ais.Substring (st, ais.Length - st);
			//Console.WriteLine(ais_str);

			int x=0, y=0,ais_s=0,ais_f=0;
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
			int z,x;

			for (x=0; x<sixbit.Length; x++) {
				z=sixbit[x];
				//y=(x+1)*6-5;
				//Console.WriteLine(six_bit_table[z]);
				ais_bin += six_bit_table [z];
			}

			//Console.WriteLine(ais_bin);
			return ais_bin;
		}
	}
}
