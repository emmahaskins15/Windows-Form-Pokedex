using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class frmPokedex : Form
    {
        string strResource;
        int intNumber;
        List<Caught> myPokemon = new List<Caught>();

        public frmPokedex()
        {
            InitializeComponent();
            picCaught.Visible = false;
        }

        public void searchPokemon(string name)
        {
            try
            {
                txtSearch.Text = this.pokemonTableAdapter.fillName(name).ToString();
                lblType1.Text = this.pokemonTableAdapter.fillType1(name).ToString().ToUpper();
                if (this.pokemonTableAdapter.fillType2(name) != null)
                    lblType2.Text = this.pokemonTableAdapter.fillType2(name).ToString().ToUpper();
                else
                    lblType2.Text = "";
                lblHeight.Text = this.pokemonTableAdapter.fillHeight(name).ToString() + "m";
                lblWeight.Text = this.pokemonTableAdapter.fillWeight(name).ToString() + "kg";
                lblNumber.Text = this.pokemonTableAdapter.fillId(name).ToString();
                strResource = this.pokemonTableAdapter.fillId(name) + ".gif";
                intNumber = (int)this.pokemonTableAdapter.fillId(name);
                picSprite.Image = Image.FromFile("sprites/" + strResource);
            }
            catch
            {
                MessageBox.Show(txtSearch.Text + " not found.");
            }


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string name = txtSearch.Text;
            searchPokemon(name);
            checkCaught();
 
        }

        private void frmPokedex_Load(object sender, EventArgs e)
        {
            searchPokemon("Bulbasaur");
            checkCaught();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkCaught()
        {
            if (myPokemon.Count != 0)
            {
                for (int i = 0; i < myPokemon.Count; i++)
                {
                    if (myPokemon[i].Id == intNumber)
                    {
                        picCaught.Visible = true;
                    }
                    else
                    {
                        picCaught.Visible = false;
                    }
                }
            }
        }
        private void chkCaught_Click(object sender, EventArgs e)
        {
            Caught newPokemon = new Caught();
            newPokemon.Id = Convert.ToInt32(lblNumber.Text);
            newPokemon.Name = txtSearch.Text;
            myPokemon.Add(newPokemon);
            checkCaught();
        }
    }
}
