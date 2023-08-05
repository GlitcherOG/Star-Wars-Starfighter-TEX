using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Star_Wars_Starfighter_TEX
{
    public class TexHandler
    {
        public string MagicWords = "";

        public int Game { get
            {
                if (MagicWords == "FTAY")
                {
                    return 0;
                }
                if (MagicWords == "YATF")
                {
                    return 1;
                }
                return -1;
            } }

        public int VersionID; //2-jedi star fighter. 1-starfighter
        public int ImageType;
        public int U1;
        public int U2;
        public int U3;

        public int Height;
        public int Width;

        public List<Color> colorTable = new List<Color>();
        public byte[] ImageMatrix = new byte[4];
        public Bitmap bitmap = new Bitmap(1,1);
        public void Load(string path)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                MagicWords = StreamUtil.ReadString(stream, 4);
                VersionID = StreamUtil.ReadInt16(stream);
                ImageType = StreamUtil.ReadInt8(stream);
                U1 = StreamUtil.ReadInt8(stream);
                U2 = StreamUtil.ReadInt16(stream);
                U3 = StreamUtil.ReadInt16(stream);

                Height = StreamUtil.ReadUInt32(stream);
                Width = StreamUtil.ReadUInt32(stream);

                if(MagicWords == "FTAY")
                {
                    LoadSImages(stream, path);
                }
                else if(MagicWords == "YATF")
                {
                    LoadJSImages(stream, path);
                }
            }
        }

        public void LoadSImages(Stream stream, string path)
        {
            if (ImageType == 0)
            {
                colorTable = new List<Color>();
                for (int i = 0; i < 256; i++)
                {
                    colorTable.Add(StreamUtil.ReadColour(stream));
                }
                ImageMatrix = new byte[Width * Height];
                for (int i = 0; i < ImageMatrix.Length; i++)
                {
                    ImageMatrix[i] = (byte)stream.ReadByte();
                }

                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        bitmap.SetPixel(x, y, colorTable[ImageMatrix[y * Width + x]]);
                    }
                }
            }
            else if (ImageType == 2)
            {
                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int R = stream.ReadByte();
                        int G = stream.ReadByte();
                        int B = stream.ReadByte();

                        bitmap.SetPixel(x, y, Color.FromArgb(255, R, G, B));
                    }
                }
            }
            else if (ImageType == 3)
            {
                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int R = stream.ReadByte();
                        int G = stream.ReadByte();
                        int B = stream.ReadByte();
                        int A = stream.ReadByte();

                        bitmap.SetPixel(x, y, Color.FromArgb(A, R, G, B));
                    }
                }
            }
            else
            {
                MessageBox.Show("Unknown Type " + ImageType + " " + path);
            }
        }

        public void LoadJSImages(Stream stream, string path)
        {
            //Type 5 is 4bit colour table of 16

            if (ImageType == 1)
            {
                colorTable = new List<Color>();
                for (int i = 0; i < 256; i++)
                {
                    colorTable.Add(StreamUtil.ReadColour(stream));
                }
                ImageMatrix = new byte[Width * Height];
                for (int i = 0; i < ImageMatrix.Length; i++)
                {
                    ImageMatrix[i] = (byte)stream.ReadByte();
                }

                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        bitmap.SetPixel(x, y, colorTable[ImageMatrix[y * Width + x]]);
                    }
                }
            }
            else if (ImageType == 3)
            {
                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int R = stream.ReadByte();
                        int G = stream.ReadByte();
                        int B = stream.ReadByte();

                        bitmap.SetPixel(x, y, Color.FromArgb(255, R, G, B));
                    }
                }
            }
            else if (ImageType == 4)
            {
                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        int R = stream.ReadByte();
                        int G = stream.ReadByte();
                        int B = stream.ReadByte();
                        int A = stream.ReadByte();

                        bitmap.SetPixel(x, y, Color.FromArgb(A, R, G, B));
                    }
                }
            }
            else if (ImageType == 5)
            {
                colorTable = new List<Color>();
                for (int i = 0; i < 16; i++)
                {
                    colorTable.Add(StreamUtil.ReadColour(stream));
                }
                ImageMatrix = new byte[Width * Height];
                int posPoint = 0;
                for (int a = 0; a < ImageMatrix.Length / 2; a++)
                {
                    byte TempByte = (byte)stream.ReadByte();
                    ImageMatrix[posPoint] = (byte)ByteUtil.ByteToBitConvert(TempByte, 0, 3);
                    posPoint++;
                    ImageMatrix[posPoint] = (byte)ByteUtil.ByteToBitConvert(TempByte, 4, 7);
                    posPoint++;
                }

                bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        bitmap.SetPixel(x, y, colorTable[ImageMatrix[y * Width + x]]);
                    }
                }
            }
            else
            {
                MessageBox.Show("Unknown Type " + ImageType + " " + path);
            }
        }

        public void SetGame(int gameID)
        {
            if(gameID==0)
            {
                MagicWords = "FTAY";
                VersionID = 1;
            }
            if (gameID == 1)
            {
                MagicWords = "YATF";
                VersionID = 2;
            }
        }

        public string CheckForError()
        {
            string Error = "";

            if(Game==0)
            {
                if(ImageType==0)
                {
                    //Test for 256 colours
                    List<Color> colors = new List<Color>();
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            if(!colors.Contains(bitmap.GetPixel(x,y)))
                            {
                                colors.Add(bitmap.GetPixel(x, y));
                            }
                            if (colors.Count > 256)
                            {
                                y = bitmap.Height + 1;
                                x = bitmap.Width + 1;
                            }
                        }
                    }

                    if(colors.Count>256)
                    {
                        Error = "Error To Many Colours Detected";  
                    }
                }
            }
            if (Game == 1)
            {
                if(ImageType==1)
                {
                    //Test for 256 colours
                    List<Color> colors = new List<Color>();
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            if (!colors.Contains(bitmap.GetPixel(x, y)))
                            {
                                colors.Add(bitmap.GetPixel(x, y));
                            }
                            if (colors.Count > 256)
                            {
                                y = bitmap.Height + 1;
                                x = bitmap.Width + 1;
                            }
                        }
                    }

                    if (colors.Count > 256)
                    {
                        Error = "Error To Many Colours Detected";
                    }
                }
                if (ImageType == 5)
                {
                    //Test for 256 colours
                    List<Color> colors = new List<Color>();
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        for (int x = 0; x < bitmap.Width; x++)
                        {
                            if (!colors.Contains(bitmap.GetPixel(x, y)))
                            {
                                colors.Add(bitmap.GetPixel(x, y));
                            }
                            if (colors.Count > 16)
                            {
                                y = bitmap.Height + 1;
                                x = bitmap.Width + 1;
                            }
                        }
                    }

                    if (colors.Count > 16)
                    {
                        Error = "Error To Many Colours Detected";
                    }
                }
            }



            return Error;
        }

        public void Save(string path)
        {
            Stream stream = new MemoryStream();

            StreamUtil.WriteString(stream, MagicWords, 4);
            StreamUtil.WriteInt16(stream, VersionID);
            StreamUtil.WriteUInt8(stream, ImageType);
            StreamUtil.WriteUInt8(stream, U1);
            StreamUtil.WriteInt16(stream, U2);
            StreamUtil.WriteInt16(stream, U3);

            StreamUtil.WriteInt32(stream, bitmap.Height);
            StreamUtil.WriteInt32(stream, bitmap.Width);

            if(Game==0)
            {
                SaveSImages(stream);
            }
            else if (Game == 1)
            {
                SaveJSImages(stream);
            }

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var file = File.Create(path);
            stream.Position = 0;
            stream.CopyTo(file);
            stream.Dispose();
            file.Close();
        }

        public void SaveSImages(Stream stream)
        {
            if(ImageType==0)
            {
                //Test for 256 colours
                List<Color> colors = new List<Color>();
                byte[] matrix = new byte[bitmap.Height * bitmap.Width];
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        if (!colors.Contains(bitmap.GetPixel(x, y)))
                        {
                            colors.Add(bitmap.GetPixel(x, y));
                            matrix[y * bitmap.Width + x] = (byte)(colors.Count - 1);
                        }
                        else
                        {
                            matrix[y * bitmap.Width + x] = (byte)colors.IndexOf(bitmap.GetPixel(x, y));
                        }
                    }
                }

                for (int i = 0; i < colors.Count; i++)
                {
                    StreamUtil.WriteUInt8(stream, colors[i].R);
                    StreamUtil.WriteUInt8(stream, colors[i].G);
                    StreamUtil.WriteUInt8(stream, colors[i].B);
                    StreamUtil.WriteUInt8(stream, colors[i].A);
                }

                for (int i = 0; i + colors.Count < 256; i++)
                {
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0xFF);
                }

                StreamUtil.WriteBytes(stream, matrix);

            }
            if(ImageType==2)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);

                        StreamUtil.WriteUInt8(stream, color.R);
                        StreamUtil.WriteUInt8(stream, color.G);
                        StreamUtil.WriteUInt8(stream, color.B);
                    }
                }
            }
            if (ImageType == 3)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);

                        StreamUtil.WriteUInt8(stream, color.R);
                        StreamUtil.WriteUInt8(stream, color.G);
                        StreamUtil.WriteUInt8(stream, color.B);
                        StreamUtil.WriteUInt8(stream, color.A);
                    }
                }
            }
        }

        public void SaveJSImages(Stream stream)
        {
            if (ImageType == 1)
            {
                //Test for 256 colours
                List<Color> colors = new List<Color>();
                byte[] matrix = new byte[bitmap.Height * bitmap.Width];
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        if (!colors.Contains(bitmap.GetPixel(x, y)))
                        {
                            colors.Add(bitmap.GetPixel(x, y));
                            matrix[y * bitmap.Width + x] = (byte)(colors.Count - 1);
                        }
                        else
                        {
                            matrix[y * bitmap.Width + x] = (byte)colors.IndexOf(bitmap.GetPixel(x, y));
                        }
                    }
                }

                for (int i = 0; i < colors.Count; i++)
                {
                    StreamUtil.WriteUInt8(stream, colors[i].R);
                    StreamUtil.WriteUInt8(stream, colors[i].G);
                    StreamUtil.WriteUInt8(stream, colors[i].B);
                    StreamUtil.WriteUInt8(stream, colors[i].A);
                }

                for (int i = 0; i+colors.Count < 256; i++)
                {
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0xFF);
                }

                StreamUtil.WriteBytes(stream, matrix);
            }
            if (ImageType == 3)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);

                        StreamUtil.WriteUInt8(stream, color.R);
                        StreamUtil.WriteUInt8(stream, color.G);
                        StreamUtil.WriteUInt8(stream, color.B);
                    }
                }
            }
            if (ImageType == 4)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color color = bitmap.GetPixel(x, y);

                        StreamUtil.WriteUInt8(stream, color.R);
                        StreamUtil.WriteUInt8(stream, color.G);
                        StreamUtil.WriteUInt8(stream, color.B);
                        StreamUtil.WriteUInt8(stream, color.A);
                    }
                }
            }
            if (ImageType == 5)
            {
                List<Color> colors = new List<Color>();
                byte[] tempByte;
                byte[] matrix = new byte[(bitmap.Height * bitmap.Width)/2];
                byte[] ByteCombine = new byte[2];
                int bytepos = 0;
                int matrixpos = 0;
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        if (!colors.Contains(bitmap.GetPixel(x, y)))
                        {
                            colors.Add(bitmap.GetPixel(x, y));
                            ByteCombine[bytepos] = (byte)(colors.Count - 1);
                        }
                        else
                        {
                            ByteCombine[bytepos]  = (byte)colors.IndexOf(bitmap.GetPixel(x, y));
                        }

                        bytepos++;

                        if (bytepos == 2)
                        {
                            bytepos = 0;
                            tempByte = new byte[4];
                            BitConverter.GetBytes(ByteUtil.BitConbineConvert(ByteCombine[0], ByteCombine[1], 0, 4, 4)).CopyTo(tempByte, 0);
                            ByteCombine = new byte[2];
                            matrix[matrixpos] = tempByte[0];
                            matrixpos++;
                        }
                    }
                }

                for (int i = 0; i < colors.Count; i++)
                {
                    StreamUtil.WriteUInt8(stream, colors[i].R);
                    StreamUtil.WriteUInt8(stream, colors[i].G);
                    StreamUtil.WriteUInt8(stream, colors[i].B);
                    StreamUtil.WriteUInt8(stream, colors[i].A);
                }

                for (int i = 0; i + colors.Count < 16; i++)
                {
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0);
                    StreamUtil.WriteUInt8(stream, 0xFF);
                }

                StreamUtil.WriteBytes(stream, matrix);
            }
        }
    }
}
