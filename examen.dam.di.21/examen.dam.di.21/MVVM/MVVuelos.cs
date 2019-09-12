using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using examen.dam.di._21.Modelo;
using examen.dam.di._21.Servicios;

namespace examen.dam.di._21.MVVM
{
    public class MVVuelos : MVBase
    {
        private aerolineasEntities aEnt;
        private ServicioVuelos serVuelos;
        private ServicioAvion serAvion;
        private ServicioCiudades serCiudades;

        private ListCollectionView lista;
        private vuelos vuelo;

        public MVVuelos(aerolineasEntities ent)
        {
            this.aEnt = ent;
            inicializar();
        }

        private void inicializar()
        {
            serVuelos = new ServicioVuelos(aEnt);
            serAvion = new ServicioAvion(aEnt);
            serCiudades = new ServicioCiudades(aEnt);
            vuelo = new vuelos();
            lista = new ListCollectionView(serVuelos.getAll().ToList());
            vuelo.Dia = DateTime.Now;
        }

        public List<vuelos> listaVuelos
        {
            get
            {
                return serVuelos.getAll().ToList();
            }
        }

        public List<avion> listaAviones
        {
            get
            {
                return serAvion.getAll().ToList();
            }
        }

        public List<ciudades> listaCiudades
        {
            get
            {
                return serCiudades.getAll().ToList();
            }
        }

        public vuelos nuevoVuelo
        {
            get
            {
                return vuelo;
            }
            set
            {
                vuelo = value;
                OnPropertyChanged("nuevoVuelo");
            }
        }

        public bool guarda()
        {
            bool correcto = true;
            serVuelos.add(vuelo);
            try
            {
                serVuelos.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
            }
            return correcto;
        }

        public bool edita()
        {
            bool correcto = true;
            serVuelos.edit(vuelo);
            try
            {
                serVuelos.save();
            }
            catch (DbUpdateException dbex)
            {
                correcto = false;
            }
            return correcto;
        }

    }
}

