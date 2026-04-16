using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity; // needed for Include()

namespace Library
{
    public partial class Library : Form
    {
        // tracks selected record id for edit/update/delete
        private int editId = -1;
        public Library()
        {
            InitializeComponent();

            // disable tab stop so radio buttons are not selected automatically by focus
            rbBooks.TabStop = false;
            rbReaders.TabStop = false;
            rbBorrowings.TabStop = false;
            rbEvents.TabStop = false;

            // Prevent ugly default exception dialog and make debugging easier
            dataGridView1.DataError += DataGridView1_DataError;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false; // предотвратява празния "new row"
            dataGridView1.AutoGenerateColumns = true;  // ако искаш да се генерират колони автоматично

            // Wire up the cell click handler so selecting a row fills the textboxes
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new LibraryEntities())
            {
                // IMPORTANT: disable proxy creation and lazy loading so entities won't try to lazy-load
                // navigation properties after the context is disposed.
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                if (rbBooks.Checked)
                {
                    // Show scalar fields and both related ids and related names (authors/categories)
                    dataGridView1.DataSource = context.Books
                        .Include(b => b.Authors)
                        .Include(b => b.Categories)
                        .Select(b => new
                        {
                            Id = b.id,
                            Heading = b.heading,
                            Year = b.year,
                            AuthorId = b.author_id,
                            Author = b.Authors != null ? b.Authors.name : null,
                            CategoryId = b.category_id,
                            Category = b.Categories != null ? b.Categories.name : null,
                            BorrowingsCount = b.Borrowings.Count()
                        })
                        .ToList();
                }
                else if (rbReaders.Checked)
                {
                    dataGridView1.DataSource = context.Readers
                        .Select(r => new
                        {
                            Id = r.id,
                            Name = r.name,
                            Email = r.email,
                            PhoneNumber = r.phone_number,
                            DateRegistration = r.date_registration
                        })
                        .ToList();
                }
                else if (rbBorrowings.Checked)
                {
                    // Project borrowings including ids (hidden) and readable names
                    dataGridView1.DataSource = context.Borrowings
                        .Include(b => b.Readers)
                        .Include(b => b.Books)
                        .Include(b => b.Librarians)
                        .Select(b => new
                        {
                            Id = b.id,
                            ReaderId = b.reader_id,
                            Reader = b.Readers != null ? b.Readers.name : null,
                            BookId = b.book_id,
                            Book = b.Books != null ? b.Books.heading : null,
                            LibrarianId = b.librarian_id,
                            Librarian = b.Librarians != null ? b.Librarians.name : null,
                            DateGot = b.date_got,
                            DateReturn = b.date_return,
                            Status = b.status
                        })
                        .ToList();

                    // hide numeric id columns, but keep them in the DataSource so selection/updates can read them
                    if (dataGridView1.Columns.Contains("ReaderId"))
                        dataGridView1.Columns["ReaderId"].Visible = false;
                    if (dataGridView1.Columns.Contains("BookId"))
                        dataGridView1.Columns["BookId"].Visible = false;
                    if (dataGridView1.Columns.Contains("LibrarianId"))
                        dataGridView1.Columns["LibrarianId"].Visible = false;
                }
                else if (rbEvents.Checked)
                {
                    dataGridView1.DataSource = context.Events
                        .Include(ev => ev.Librarians)
                        .Select(ev => new
                        {
                            Id = ev.id,
                            Name = ev.name,
                            Date = ev.date,
                            Description = ev.description,
                            LibrarianId = ev.librarian_id,
                            Librarian = ev.Librarians != null ? ev.Librarians.name : null
                        })
                        .ToList();
                }
            }

            // Clear selection so editId isn't stale
            if (dataGridView1.Rows.Count > 0)
                dataGridView1.ClearSelection();
            editId = -1;
        }

        // =========================
        // RADIO BUTTONS
        // =========================
        private void rbBooks_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
            LoadFilters();

            label2.Text = "Year";
            label3.Text = "Author";
            label4.Text = "Category";
            label1.Text = "Heading";
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
        }

        private void rbReaders_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
            LoadFilters();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            label1.Text = "Name";
            label2.Text = "Email";
            label3.Text = @"Phone
Number";
            label4.Text = @"Date of the
Registration";
        }

        private void rbBorrowings_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
            LoadFilters();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            label1.Text = "Reader";
            label2.Text = "Book";
            label3.Text = "Librarian";
            label4.Text = "DateGot";
            label5.Text = @"DateReturn /
Status";
        }

        private void rbEvents_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
            LoadFilters();
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = false;
            label1.Text = "Name";
            label2.Text = "Date";
            label3.Text = "Description";
            label4.Text = "Librarian";
        }

        // =========================
        // FILTER OPTIONS
        // =========================
        private void LoadFilters()
        {
            cbFilter.Items.Clear();

            if (rbBooks.Checked)
            {
                // Add Id as first option so default sort is by id
                cbFilter.Items.Add("Id");
                cbFilter.Items.Add("Heading");
                cbFilter.Items.Add("Year");
                cbFilter.Items.Add("Author");
                cbFilter.Items.Add("Category");
            }
            else if (rbReaders.Checked)
            {
                cbFilter.Items.Add("Name");
                cbFilter.Items.Add("Email");
                // added: allow sorting readers by registration date
                cbFilter.Items.Add("DateRegistration");
            }
            else if (rbBorrowings.Checked)
            {
                cbFilter.Items.Add("Status");
                cbFilter.Items.Add("Reader");
                cbFilter.Items.Add("Book");
                cbFilter.Items.Add("Librarian");
            }
            else if (rbEvents.Checked)
            {
                cbFilter.Items.Add("Name");
                cbFilter.Items.Add("Date");
                cbFilter.Items.Add("Librarian");
            }

            if (cbFilter.Items.Count > 0)
                cbFilter.SelectedIndex = 0;
        }

        // =========================
        // INSERT
        // =========================
        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryEntities())
            {
                if (rbBooks.Checked)
                {
                    context.Books.Add(new Books
                    {
                        heading = textBox1.Text,
                        year = int.Parse(textBox2.Text),
                        author_id = int.Parse(textBox3.Text),
                        category_id = int.Parse(textBox4.Text)
                    });
                }
                else if (rbReaders.Checked)
                {
                    context.Readers.Add(new Readers
                    {
                        name = textBox1.Text,
                        email = textBox2.Text,
                        phone_number = textBox3.Text,
                        date_registration = DateTime.Parse(textBox4.Text)
                    });
                }
                else if (rbBorrowings.Checked)
                {
                    // insert expects ids; user can type ids or you can extend UI to resolve names -> ids
                    context.Borrowings.Add(new Borrowings
                    {
                        librarian_id = int.Parse(textBox3.Text), // currently textBox3 label is Librarian (id expected)
                        reader_id = int.Parse(textBox1.Text),
                        book_id = int.Parse(textBox2.Text),
                        date_got = DateTime.Parse(textBox4.Text),
                        date_return = DateTime.TryParse(textBox5.Text, out var dr) ? (DateTime?)dr : null,
                        status = ""
                    });
                }
                else if (rbEvents.Checked)
                {
                    context.Events.Add(new Events
                    {
                        name = textBox1.Text,
                        date = DateTime.Parse(textBox2.Text),
                        description = textBox3.Text,
                        librarian_id = int.Parse(textBox4.Text)
                    });
                }

                context.SaveChanges();
            }

            LoadData();
            ClearTextBoxes();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];

            // опитваме да прочетем DataBoundItem (анонимният тип от Select)
            var dataItem = row.DataBoundItem;

            // helper: чете стойност първо от DataBoundItem чрез рефлексия, иначе от клетка (по DataPropertyName/HeaderText/Name/индекс)
            Func<string, int, string> getValue = (propName, fallbackIndex) =>
            {
                if (dataItem != null)
                {
                    var pi = dataItem.GetType().GetProperty(propName);
                    if (pi != null)
                        return pi.GetValue(dataItem)?.ToString() ?? string.Empty;
                }

                // търсим клетка по DataPropertyName или HeaderText или Column.Name
                var cell = row.Cells
                    .Cast<DataGridViewCell>()
                    .FirstOrDefault(c =>
                        string.Equals(c.OwningColumn.DataPropertyName, propName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(c.OwningColumn.HeaderText, propName, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(c.OwningColumn.Name, propName, StringComparison.OrdinalIgnoreCase));

                if (cell != null)
                    return cell.Value?.ToString() ?? string.Empty;

                // fallback по индекс
                if (fallbackIndex >= 0 && fallbackIndex < row.Cells.Count)
                    return row.Cells[fallbackIndex].Value?.ToString() ?? string.Empty;

                return string.Empty;
            };

            // прочитаме Id (от DataBoundItem или клетка)
            var idText = getValue("Id", 0);
            if (!int.TryParse(idText, out editId))
                editId = -1;

            // попълваме textbox-овете според режима
            if (rbBooks.Checked)
            {
                // projection: Id(0), Heading(1), Year(2), AuthorId(3), Author(4), CategoryId(5), Category(6), BorrowingsCount(7)
                textBox1.Text = getValue("Heading", 1);
                textBox2.Text = getValue("Year", 2);
                // now show author id and category id in the textboxes (not names)
                textBox3.Text = getValue("AuthorId", 3);
                textBox4.Text = getValue("CategoryId", 5);
            }
            else if (rbReaders.Checked)
            {
                textBox1.Text = getValue("Name", 1);
                textBox2.Text = getValue("Email", 2);
                textBox3.Text = getValue("PhoneNumber", 3);
                textBox4.Text = getValue("DateRegistration", 4);
            }
            else if (rbBorrowings.Checked)
            {
                // projection: Id(0), ReaderId(1), Reader(2), BookId(3), Book(4), LibrarianId(5), Librarian(6), DateGot(7), DateReturn(8), Status(9)
                textBox1.Text = getValue("ReaderId", 1);
                textBox2.Text = getValue("BookId", 3);
                // show librarian id (not name) in textBox3 (matching Insert/Update expectations)
                textBox3.Text = getValue("LibrarianId", 5);
                textBox4.Text = getValue("DateGot", 7);
                textBox5.Text = getValue("DateReturn", 8);
            }
            else if (rbEvents.Checked)
            {
                // projection: Id(0), Name(1), Date(2), Description(3), LibrarianId(4), Librarian(5)
                textBox1.Text = getValue("Name", 1);
                textBox2.Text = getValue("Date", 2);
                textBox3.Text = getValue("Description", 3);
                // show librarian id in textBox4
                textBox4.Text = getValue("LibrarianId", 4);
            }

            // визуална селекция
            dataGridView1.ClearSelection();
            row.Selected = true;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                string field = cbFilter.Text;
                string value = txtFilter.Text ?? string.Empty;

                if (rbBooks.Checked)
                {
                    var q = context.Books.AsQueryable();

                    // support all cbFilter options for books: Id, Heading, Year, Author, Category
                    if (field == "Id")
                    {
                        if (int.TryParse(value, out var id))
                            q = q.Where(b => b.id == id);
                        else
                            q = q.Where(b => b.id.ToString().Contains(value)); // fallback textual match
                    }
                    else if (field == "Heading")
                        q = q.Where(x => x.heading.Contains(value));
                    else if (field == "Year")
                    {
                        if (int.TryParse(value, out var yr))
                            q = q.Where(x => x.year == yr);
                        else
                            q = q.Where(x => x.year.ToString().Contains(value));
                    }
                    else if (field == "Author")
                        q = q.Include(b => b.Authors).Where(x => x.Authors != null && x.Authors.name.Contains(value));
                    else if (field == "Category")
                        q = q.Include(b => b.Categories).Where(x => x.Categories != null && x.Categories.name.Contains(value));

                    dataGridView1.DataSource = q
                        .Include(b => b.Authors)
                        .Include(b => b.Categories)
                        .Select(b => new { Id = b.id, Heading = b.heading, Year = b.year, AuthorId = b.author_id, Author = b.Authors != null ? b.Authors.name : null, CategoryId = b.category_id, Category = b.Categories != null ? b.Categories.name : null, BorrowingsCount = b.Borrowings.Count() })
                        .ToList();
                }
                else if (rbReaders.Checked)
                {
                    var q = context.Readers.AsQueryable();

                    if (field == "Name")
                        q = q.Where(x => x.name.Contains(value));
                    else if (field == "Email")
                        q = q.Where(x => x.email.Contains(value));
                    else if (field == "DateRegistration")
                    {
                        DateTime dt;
                        if (DateTime.TryParse(value, out dt))
                        {
                            // match by date (date component only)
                            q = q.Where(x => DbFunctions.TruncateTime(x.date_registration) == DbFunctions.TruncateTime(dt));
                        }
                        else
                        {
                            // fallback textual match
                            q = q.Where(x => x.date_registration.ToString().Contains(value));
                        }
                    }

                    dataGridView1.DataSource = q
                        .Select(r => new { Id = r.id, Name = r.name, Email = r.email, PhoneNumber = r.phone_number, DateRegistration = r.date_registration })
                        .ToList();
                }
                else if (rbBorrowings.Checked)
                {
                    var q = context.Borrowings
                        .Include(b => b.Readers)
                        .Include(b => b.Books)
                        .Include(b => b.Librarians)
                        .AsQueryable();

                    if (field == "Status")
                        q = q.Where(x => x.status.Contains(value));
                    else if (field == "Reader")
                        q = q.Where(x => x.Readers != null && x.Readers.name.Contains(value));
                    else if (field == "Book")
                        q = q.Where(x => x.Books != null && x.Books.heading.Contains(value));
                    else if (field == "Librarian")
                        q = q.Where(x => x.Librarians != null && x.Librarians.name.Contains(value));

                    dataGridView1.DataSource = q
                        .Select(b => new
                        {
                            Id = b.id,
                            ReaderId = b.reader_id,
                            Reader = b.Readers != null ? b.Readers.name : null,
                            BookId = b.book_id,
                            Book = b.Books != null ? b.Books.heading : null,
                            LibrarianId = b.librarian_id,
                            Librarian = b.Librarians != null ? b.Librarians.name : null,
                            DateGot = b.date_got,
                            DateReturn = b.date_return,
                            Status = b.status
                        })
                        .ToList();

                    if (dataGridView1.Columns.Contains("ReaderId"))
                        dataGridView1.Columns["ReaderId"].Visible = false;
                    if (dataGridView1.Columns.Contains("BookId"))
                        dataGridView1.Columns["BookId"].Visible = false;
                    if (dataGridView1.Columns.Contains("LibrarianId"))
                        dataGridView1.Columns["LibrarianId"].Visible = false;
                }
                else if (rbEvents.Checked)
                {
                    var q = context.Events.Include(ev => ev.Librarians).AsQueryable();

                    if (field == "Name")
                        q = q.Where(x => x.name.Contains(value));
                    else if (field == "Date")
                    {
                        DateTime dt;
                        if (DateTime.TryParse(value, out dt))
                            q = q.Where(x => DbFunctions.TruncateTime(x.date) == DbFunctions.TruncateTime(dt));
                        else
                            q = q.Where(x => x.date.ToString().Contains(value));
                    }
                    else if (field == "Librarian")
                        q = q.Where(x => x.Librarians != null && x.Librarians.name.Contains(value));

                    dataGridView1.DataSource = q
                        .Select(ev => new { Id = ev.id, Name = ev.name, Date = ev.date, Description = ev.description, LibrarianId = ev.librarian_id, Librarian = ev.Librarians != null ? ev.Librarians.name : null })
                        .ToList();
                }
            }
        }
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            editId = -1;
        }
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (editId <= 0)
            {
                MessageBox.Show("Няма избран запис за ъпдейт. Изберете ред от таблицата.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new LibraryEntities())
            {
                try
                {
                    if (rbBooks.Checked)
                    {
                        var b = context.Books.Find(editId);
                        if (b == null)
                        {
                            MessageBox.Show("Книгата не е намерена в базата (вероятно е изтрита).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!int.TryParse(textBox2.Text, out var year))
                        {
                            MessageBox.Show("Невалиден Year.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(textBox3.Text, out var authorId))
                        {
                            MessageBox.Show("Невалиден Author id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(textBox4.Text, out var categoryId))
                        {
                            MessageBox.Show("Невалиден Category id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        b.heading = textBox1.Text;
                        b.year = year;
                        b.author_id = authorId;
                        b.category_id = categoryId;
                    }
                    else if (rbReaders.Checked)
                    {
                        var r = context.Readers.Find(editId);
                        if (r == null)
                        {
                            MessageBox.Show("Читателят не е намерен в базата.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!DateTime.TryParse(textBox4.Text, out var regDate))
                        {
                            MessageBox.Show("Невалидна дата на регистрация.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        r.name = textBox1.Text;
                        r.email = textBox2.Text;
                        r.phone_number = textBox3.Text;
                        r.date_registration = regDate;
                    }
                    else if (rbBorrowings.Checked)
                    {
                        var br = context.Borrowings.Find(editId);
                        if (br == null)
                        {
                            MessageBox.Show("Заемането не е намерено в базата.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!int.TryParse(textBox1.Text, out var readerId))
                        {
                            MessageBox.Show("Невалиден Reader id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(textBox2.Text, out var bookId))
                        {
                            MessageBox.Show("Невалиден Book id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!int.TryParse(textBox3.Text, out var librarianId))
                        {
                            MessageBox.Show("Невалиден Librarian id.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (!DateTime.TryParse(textBox4.Text, out var dateGot))
                        {
                            MessageBox.Show("Невалидна дата (DateGot).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        br.reader_id = readerId;
                        br.book_id = bookId;
                        br.librarian_id = librarianId;
                        br.date_got = dateGot;
                        br.date_return = DateTime.TryParse(textBox5.Text, out var dr) ? (DateTime?)dr : null;
                    }
                    else if (rbEvents.Checked)
                    {
                        var ev = context.Events.Find(editId);
                        if (ev == null)
                        {
                            MessageBox.Show("Събитието не е намерено в базата.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (!DateTime.TryParse(textBox2.Text, out var evDate))
                        {
                            MessageBox.Show("Невалидна дата за събитието.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ev.name = textBox1.Text;
                        ev.date = evDate;
                        ev.description = textBox3.Text;
                        if (int.TryParse(textBox4.Text, out var libId))
                            ev.librarian_id = libId;
                    }

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            LoadData();
            ClearTextBoxes();
        }

        private void btnSort_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var context = new LibraryEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    context.Configuration.LazyLoadingEnabled = false;

                    var sortKey = (cbFilter.Text ?? string.Empty).Trim();

                    if (rbBooks.Checked)
                    {
                        var q = context.Books.AsQueryable();
                        switch (sortKey)
                        {
                            case "Id":
                                q = q.OrderBy(b => b.id);
                                break;
                            case "Heading":
                                q = q.OrderBy(b => b.heading);
                                break;
                            case "Year":
                                q = q.OrderBy(b => b.year);
                                break;
                            case "Author":
                                // order by related author's name
                                q = q.Include(b => b.Authors).OrderBy(b => b.Authors.name);
                                break;
                            case "Category":
                                // order by related category's name
                                q = q.Include(b => b.Categories).OrderBy(b => b.Categories.name);
                                break;
                            default:
                                q = q.OrderBy(b => b.id);
                                break;
                        }

                        if (cbDescending != null && cbDescending.Checked)
                        {
                            switch (sortKey)
                            {
                                case "Id":
                                    q = q.OrderByDescending(b => b.id);
                                    break;
                                case "Heading":
                                    q = q.OrderByDescending(b => b.heading);
                                    break;
                                case "Year":
                                    q = q.OrderByDescending(b => b.year);
                                    break;
                                case "Author":
                                    q = q.Include(b => b.Authors).OrderByDescending(b => b.Authors.name);
                                    break;
                                case "Category":
                                    q = q.Include(b => b.Categories).OrderByDescending(b => b.Categories.name);
                                    break;
                                default:
                                    q = q.OrderByDescending(b => b.id);
                                    break;
                            }
                        }

                        dataGridView1.DataSource = q
                            .Include(b => b.Authors)
                            .Include(b => b.Categories)
                            .Select(b => new { Id = b.id, Heading = b.heading, Year = b.year, AuthorId = b.author_id, Author = b.Authors != null ? b.Authors.name : null, CategoryId = b.category_id, Category = b.Categories != null ? b.Categories.name : null, BorrowingsCount = b.Borrowings.Count() })
                            .ToList();
                    }
                    else if (rbReaders.Checked)
                    {
                        var q = context.Readers.AsQueryable();
                        switch (sortKey)
                        {
                            case "Name":
                                q = q.OrderBy(r => r.name);
                                break;
                            case "Email":
                                q = q.OrderBy(r => r.email);
                                break;
                            case "DateRegistration":
                                q = q.OrderBy(r => r.date_registration);
                                break;
                            default:
                                q = q.OrderBy(r => r.id);
                                break;
                        }

                        // if you add a CheckBox cbDescending to the form:
                        if (cbDescending != null && cbDescending.Checked)
                        {
                            switch (sortKey)
                            {
                                case "Name":
                                    q = q.OrderByDescending(r => r.name);
                                    break;
                                case "Email":
                                    q = q.OrderByDescending(r => r.email);
                                    break;
                                case "DateRegistration":
                                    q = q.OrderByDescending(r => r.date_registration);
                                    break;
                                default:
                                    q = q.OrderByDescending(r => r.id);
                                    break;
                            }
                        }

                        dataGridView1.DataSource = q
                            .Select(r => new { Id = r.id, Name = r.name, Email = r.email, PhoneNumber = r.phone_number, DateRegistration = r.date_registration })
                            .ToList();
                    }
                    else if (rbBorrowings.Checked)
                    {
                        var q = context.Borrowings.Include(b => b.Readers).Include(b => b.Books).Include(b => b.Librarians).AsQueryable();
                        switch (sortKey)
                        {
                            case "Status":
                                q = q.OrderBy(b => b.status);
                                break;
                            case "Reader":
                                q = q.OrderBy(b => b.Readers.name);
                                break;
                            case "Book":
                                q = q.OrderBy(b => b.Books.heading);
                                break;
                            case "Librarian":
                                q = q.OrderBy(b => b.Librarians.name);
                                break;
                            default:
                                q = q.OrderBy(b => b.id);
                                break;
                        }

                        // if you add a CheckBox cbDescending to the form:
                        if (cbDescending != null && cbDescending.Checked)
                        {
                            switch (sortKey)
                            {
                                case "Status":
                                    q = q.OrderByDescending(b => b.status);
                                    break;
                                case "Reader":
                                    q = q.OrderByDescending(b => b.Readers.name);
                                    break;
                                case "Book":
                                    q = q.OrderByDescending(b => b.Books.heading);
                                    break;
                                case "Librarian":
                                    q = q.OrderByDescending(b => b.Librarians.name);
                                    break;
                                default:
                                    q = q.OrderByDescending(b => b.id);
                                    break;
                            }
                        }

                        dataGridView1.DataSource = q
                            .Select(b => new
                            {
                                Id = b.id,
                                ReaderId = b.reader_id,
                                Reader = b.Readers != null ? b.Readers.name : null,
                                BookId = b.book_id,
                                Book = b.Books != null ? b.Books.heading : null,
                                LibrarianId = b.librarian_id,
                                Librarian = b.Librarians != null ? b.Librarians.name : null,
                                DateGot = b.date_got,
                                DateReturn = b.date_return,
                                Status = b.status
                            })
                            .ToList();

                        if (dataGridView1.Columns.Contains("ReaderId"))
                            dataGridView1.Columns["ReaderId"].Visible = false;
                        if (dataGridView1.Columns.Contains("BookId"))
                            dataGridView1.Columns["BookId"].Visible = false;
                        if (dataGridView1.Columns.Contains("LibrarianId"))
                            dataGridView1.Columns["LibrarianId"].Visible = false;
                    }
                    else if (rbEvents.Checked)
                    {
                        var q = context.Events.Include(ev => ev.Librarians).AsQueryable();
                        switch (sortKey)
                        {
                            case "Name":
                                q = q.OrderBy(ev => ev.name);
                                break;
                            case "Date":
                                q = q.OrderBy(ev => ev.date);
                                break;
                            case "Librarian":
                                q = q.OrderBy(ev => ev.Librarians.name);
                                break;
                            default:
                                q = q.OrderBy(ev => ev.id);
                                break;
                        }

                        // if you add a CheckBox cbDescending to the form:
                        if (cbDescending != null && cbDescending.Checked)
                        {
                            switch (sortKey)
                            {
                                case "Name":
                                    q = q.OrderByDescending(ev => ev.name);
                                    break;
                                case "Date":
                                    q = q.OrderByDescending(ev => ev.date);
                                    break;
                                case "Librarian":
                                    q = q.OrderByDescending(ev => ev.Librarians.name);
                                    break;
                                default:
                                    q = q.OrderByDescending(ev => ev.id);
                                    break;
                            }
                        }

                        dataGridView1.DataSource = q
                            .Select(ev => new { Id = ev.id, Name = ev.name, Date = ev.date, Description = ev.description, LibrarianId = ev.librarian_id, Librarian = ev.Librarians != null ? ev.Librarians.name : null })
                            .ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sort failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}