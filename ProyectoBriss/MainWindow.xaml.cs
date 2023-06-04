using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoBriss
{
    public partial class MainWindow : Window
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DataTable personasTable;
        private DataRowView selectedRow;

        public MainWindow()
        {
            InitializeComponent();
            LoadPersonas();
        }

        private SqlConnection CrearConexion()
        {
            return new SqlConnection(connectionString);
        }

        private void LoadPersonas()
        {
            try
            {
                using (SqlConnection connection = CrearConexion())
                {
                    string query = "SELECT ID, Nombre, Edad, Telefono, Consulta FROM Personas";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    personasTable = new DataTable();
                    adapter.Fill(personasTable);

                    PersonasDataGrid.ItemsSource = personasTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las personas: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PersonasDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PersonasDataGrid.SelectedItem != null)
            {
                selectedRow = (DataRowView)PersonasDataGrid.SelectedItem;

                TxtIDValue.Text = selectedRow["ID"].ToString();
                TxtNombre.Text = selectedRow["Nombre"].ToString();
                TxtEdad.Text = selectedRow["Edad"].ToString();
                TxtTelefono.Text = selectedRow["Telefono"].ToString();
                TxtConsulta.Text = selectedRow["Consulta"].ToString();
            }
        }

        private void BtnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRow != null)
                {
                    using (SqlConnection connection = CrearConexion())
                    {
                        string query = "UPDATE Personas SET Nombre = @nombre, Edad = @edad, Telefono = @telefono, Consulta = @consulta WHERE ID = @id";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@nombre", TxtNombre.Text);
                        command.Parameters.AddWithValue("@edad", TxtEdad.Text);

                        int telefono;
                        if (int.TryParse(TxtTelefono.Text, out telefono))
                            command.Parameters.AddWithValue("@telefono", telefono);
                        else
                            command.Parameters.AddWithValue("@telefono", DBNull.Value);

                        command.Parameters.AddWithValue("@consulta", TxtConsulta.Text);

                        int id = (int)selectedRow["ID"];
                        command.Parameters.AddWithValue("@id", id);

                        connection.Open();
                        command.ExecuteNonQuery();

                        LoadPersonas();
                        ClearInputs();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna persona.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar los datos: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (selectedRow != null)
                {
                    MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta persona?", "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (SqlConnection connection = CrearConexion())
                        {
                            string query = "DELETE FROM Personas WHERE ID = @id";
                            SqlCommand command = new SqlCommand(query, connection);
                            int id = (int)selectedRow["ID"];
                            command.Parameters.AddWithValue("@id", id);

                            connection.Open();
                            command.ExecuteNonQuery();

                            LoadPersonas();
                            ClearInputs();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se ha seleccionado ninguna persona.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la persona: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection connection = CrearConexion())
                {
                    string query = "INSERT INTO Personas (Nombre, Edad, Telefono, Consulta) VALUES (@nombre, @edad, @telefono, @consulta)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nombre", TxtNombre.Text);
                    command.Parameters.AddWithValue("@edad", TxtEdad.Text);

                    int telefono;
                    if (int.TryParse(TxtTelefono.Text, out telefono))
                        command.Parameters.AddWithValue("@telefono", telefono);
                    else
                        command.Parameters.AddWithValue("@telefono", DBNull.Value);

                    command.Parameters.AddWithValue("@consulta", TxtConsulta.Text);

                    connection.Open();
                    command.ExecuteNonQuery();

                    LoadPersonas();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar la persona: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearInputs()
        {
            TxtIDValue.Text = "";
            TxtNombre.Text = "";
            TxtEdad.Text = "";
            TxtTelefono.Text = "";
            TxtConsulta.Text = "";
            selectedRow = null;
        }
    }
}