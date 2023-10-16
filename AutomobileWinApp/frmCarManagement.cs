using AutomobileLibrary.BiussinessObject;
using AutomobileLibrary.Repository;

namespace AutomobileWinApp
{
    public partial class frmCarManagement : Form
    {
        public frmCarManagement()
        {
            InitializeComponent();
        }
        ICarRepository carRepository = new CarRepository();
        BindingSource source;
        private Action<object, DataGridViewCellEventArgs> dgvCarList_CellDoubleClick;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadCarList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails
            {
                Text = "Add car",
                InsertOrUpdate = false,
                CarRepository = carRepository,
            };
            if(frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCarList();
                source.Position = source.Position - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var car = GetCarObject();
                carRepository.DeleteCar(car.CarId);
                LoadCarList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"delete a car");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
       

        

        private void frmCarManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            dgvCarList_CellDoubleClick += DgvCarList_CellDoubleClick;
        }

        private void DgvCarList_CellDoubleClick(object arg1, DataGridViewCellEventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails {
                Text = "Update car",
            InsertOrUpdate = true,
            CarInfo = GetCarObject(),
            CarRepository = carRepository,
        };
            if(frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                LoadCarList();
                source.Position = source.Count -1;
            }

        }

        private void LoadCarList()
        {
            var cars = carRepository.GetCars();
            try
            {
                source = new BindingSource();
                source.DataSource = cars;

                txtCarID.DataBindings.Clear();
                txtCarName.DataBindings.Clear();
                txtManufacturer.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtReleaseYear.DataBindings.Clear();

                txtCarID.DataBindings.Add("text", source, "CarID");
                txtCarName.DataBindings.Add("text", source, "Carname");
                txtManufacturer.DataBindings.Add("text", source, "Manufacturer");
                txtPrice.DataBindings.Add("text", source, "Price");
                txtReleaseYear.DataBindings.Add("text", source, "ReleaseYear");

                dgvCarList.DataSource = null;
                dgvCarList.DataSource = source;
                if(cars.Count() ==0){
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load Car list");
            }
        }

        private void ClearText()
        {
            txtCarID.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtCarName.Text = string.Empty;
            txtReleaseYear.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }

        private Car GetCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    CarId = int.Parse(txtCarID.Text),
                    CarName = txtCarID.Text,
                    Manufacturer = txtManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Get car");
            }
            return car;
        }




    }
}
