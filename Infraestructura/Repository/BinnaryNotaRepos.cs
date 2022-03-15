using Dominio.Entities;
using Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repositoy
{
    public  class BinnaryNotaRepos : INotaModel
    {
        private BinaryReader binaryReader;
        private BinaryWriter binaryWriter;
      








        private string fileName = "activo.dat";
      
        public void Add(Nota t)
        {
            try
            {
                int id = 0;
                Nota lastActivo = Read().LastOrDefault();
                if (lastActivo == null)
                {
                    id = 1;
                }
                else
                {
                    id = lastActivo.Id + 1;
                }

                using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                {
                    binaryWriter = new BinaryWriter(fileStream);
                    binaryWriter.Write(id);
                    binaryWriter.Write(t.Titulo);
                    binaryWriter.Write(t.Texto);

                    binaryWriter.Close();
                }

            }
            catch (IOException)
            {
                throw;
            }
        }

        
        
        
        
        
        public void Delete(Nota t)
        {
            StreamWriter Temporal;
            try {
                
                
                Temporal = File.CreateText("temp.txt");

            
            
            }
            catch(IOException) { }
        }

        
        
        
        
        
        
        
        
        public Nota GetById(int id)
        {
            Nota activo = null;
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    binaryReader = new BinaryReader(fileStream);
                    long length = binaryReader.BaseStream.Length;

                    if (length == 0)
                    {
                        return activo;
                    }

                    binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (binaryReader.BaseStream.Position < length)
                    {
                        activo = new Nota()
                        {
                            Id = binaryReader.ReadInt32(),
                            Titulo = binaryReader.ReadString(),
                            Texto = binaryReader.ReadString(),
                           

                        };

                        if (activo.Id == id)
                        {
                            break;
                        }
                    }
                }

                return activo;
            }
            catch (IOException)
            {
                throw;
            }

        }

        public List<Nota> Read()
        {
            List<Nota> activos = new List<Nota>();
            try
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    binaryReader = new BinaryReader(fileStream);
                    long length = binaryReader.BaseStream.Length;

                    if (length == 0)
                    {
                        return activos;
                    }

                    binaryReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (binaryReader.BaseStream.Position < length)
                    {
                        activos.Add(new Nota()
                        {
                            Id = binaryReader.ReadInt32(),
                            Titulo = binaryReader.ReadString(),
                            Texto= binaryReader.ReadString(),

                        });
                    }
                }
                return activos;
            }
            catch (IOException)
            {
                throw;
            }

        }



    }
}
