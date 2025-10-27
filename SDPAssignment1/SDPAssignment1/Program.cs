using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SDPAssignment1
{
    class Program
    {
        // Static list to store all users in the system
        private static List<User> users = new List<User>();
        // Static variable to track the currently logged-in user
        private static User? currentUser;

        static void Main(string[] args)
        {
            // Infinite loop to keep the program running until the user chooses to exit
            while (true)
            {
                // Display the main menu options
                MainMenu();
                Console.Write("Enter your choice: ");
                try
                {
                    // Read user input and convert it to an integer
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            // Option to create a new user
                            CreateUser();
                            break;
                        case 2:
                            // Option to log in as an existing user
                            LoginUser();
                            if (currentUser != null)
                            {
                                // If login is successful, display the user-specific menu
                                UserMenu();
                            }
                            break;
                        case 3:
                            // Option to list all users in the system
                            ListUsers();
                            break;
                        case 4:
                            // Option to list all documents associated with the current user
                            ListDocuments();
                            break;
                        case 0:
                            // Exit the program
                            return;
                        default:
                            // Handle invalid menu choices
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Catch and display any errors that occur during input processing
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Method to display the main menu options
        static void MainMenu()
        {
            Console.WriteLine("1) Create new user");
            Console.WriteLine("2) Login as user");
            Console.WriteLine("3) List users");
            Console.WriteLine("4) List documents");
            Console.WriteLine("0) Exit");
        }

        // Method to create a new user based on the role provided by the user
        static void CreateUser()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Enter role (Owner/Collaborator/Approver): ");
            string role = Console.ReadLine() ?? "";

            // Initialize the factory variable
            UserFactory? factory = null;

            // Determine the appropriate factory based on the role using if-else
            if (role.ToLower() == "owner")
            {
                factory = new OwnerFactory();
            }
            else if (role.ToLower() == "collaborator")
            {
                factory = new CollaboratorFactory();
            }
            else if (role.ToLower() == "approver")
            {
                factory = new ApproverFactory();
            }
            else
            {
                // If the role is invalid, notify the user and exit the method
                Console.WriteLine("Invalid role. Please try again.");
                return;
            }

            // Use the factory to create the user
            User user = factory.LaunchUser(name);
            users.Add(user);
            Console.WriteLine($"{name} has been created as a {role}.");
        }

        // Method to log in a user by matching the entered name with an existing user
        static void LoginUser()
        {
            Console.Write("Enter user name: ");
            string name = Console.ReadLine() ?? "";

            // Loop through the users list to find the user
            foreach (var user in users)
            {
                if (user.Name.ToLower() == name.ToLower())
                {
                    // Set the current user and notify the user of successful login
                    currentUser = user;
                    Console.WriteLine($"Logged in as {currentUser.Name}.");
                    return; // Exit the method once the user is found
                }
            }

            // If no user is found, print an error message
            Console.WriteLine("User not found.");
        }

        // Method to list all users in the system
        static void ListUsers()
        {
            Console.WriteLine("List of users:");
            foreach (var user in users)
            {
                Console.WriteLine($"- {user.Name}");
            }
        }

        // Method to list all documents associated with the current user
        static void ListDocuments()
        {
            if (currentUser != null)
            {
                Console.WriteLine($"Documents associated with {currentUser.Name}:");
                foreach (var doc in Document.Documents)
                {
                    // Check if the current user is either the owner or a collaborator of the document
                    if (doc.Owner == currentUser || doc.Collaborators.Contains(currentUser))
                    {
                        Console.WriteLine($"- {doc.Name} (State: {doc.State.GetType().Name})");
                    }
                }
            }
            else
            {
                // Notify the user to log in first if they are not logged in
                Console.WriteLine("Please log in first.");
            }
        }

        // Method to display the user-specific menu after logging in
        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\nUser Menu:");
                Console.WriteLine("1) Create new document");
                Console.WriteLine("2) Edit document");
                Console.WriteLine("3) List documents");
                Console.WriteLine("4) Convert Document");
                Console.WriteLine("0) Logout");
                Console.Write("Enter your choice: ");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            CreateDocument();
                            break;
                        case 2:
                            EditDocument();
                            break;
                        case 3:
                            ListOwnedDocuments();
                            break;
                        case 4:
                            ConvertDocumentMenu();
                            break;
                        case 0:
                            Console.WriteLine("Logging out...");
                            currentUser = null;
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Method to display the convert document menu
        // Method to display the convert document menu
    static void ConvertDocumentMenu()
    {
        Console.WriteLine("\nConvert Document:");
        Console.WriteLine("1) Convert to PDF");
        Console.WriteLine("2) Convert to Word");
        Console.WriteLine("0) Back to User Menu");

        Console.Write("Enter your choice: ");
        try
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            DocumentProcessor documentProcessor = new DocumentProcessor();

            switch (choice)
            {
                case 1:
                    // Set the PDF conversion strategy
                    documentProcessor.SetConverter(new PDFConverter());
                    break;
                case 2:
                    // Set the Word conversion strategy
                    documentProcessor.SetConverter(new WordConverter());
                    break;
                case 0:
                    return; // Back to User Menu
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return;
            }

            // Display available documents
            documentProcessor.DisplayDocuments();

            // Select a document to convert
            Console.Write("\nEnter document number: ");
            int docChoice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (docChoice >= 0 && docChoice < Document.Documents.Count)
            {
                var document = Document.Documents[docChoice];

                // Convert the selected document using the strategy
                documentProcessor.ConvertDocument(document);

                // Print the updated document after conversion
                Console.WriteLine($"Document {document.Name} is now in {document.Extension} format.");
            }
            else
            {
                Console.WriteLine("Invalid document number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


        // Method to create a new document and assign the current user as the owner
        static void CreateDocument()
        {
            Console.Write("Enter document name: ");
            string name = Console.ReadLine() ?? "";
            Console.Write("Enter document header: ");
            string header = Console.ReadLine() ?? "";
            Console.Write("Enter document footer: ");
            string footer = Console.ReadLine() ?? "";
            Console.Write("Enter document content: ");
            string content = Console.ReadLine() ?? "";

            // Prompt the user to choose a document extension (either .pdf or .docx)
            Console.WriteLine("Choose document extension (1) .pdf (2) .docx");
            string extensionChoice = Console.ReadLine() ?? "";
            string extension = extensionChoice == "1" ? ".pdf" : ".docx"; // Set the extension based on user choice

            // Check if the document already exists with this name and extension
            Document? existingDocument = Document.Documents.FirstOrDefault(doc => doc.Name.ToLower() == name.ToLower() && doc.Extension == extension);
            
            if (existingDocument != null)
            {
                // If the document exists and has the same extension, update the content
                existingDocument.Content = content; // Update content if needed
                Console.WriteLine($"{name} with {extension} extension has been updated.");
            }
            else
            {
                // Create a new document and add it to the static list of documents
                Document document = new Document(name, header, footer, content, extension, currentUser!);
                Document.Documents.Add(document);

                // If the current user is an Owner, add the document to their OwnedDocuments list
                if (currentUser is Owner owner)
                {
                    owner.AddOwnedDocument(document);
                }

                Console.WriteLine($"{name} has been created with the {extension} extension and you are the owner.");
            }
        }


                // Method to edit an existing document
        static void EditDocument()
        {
            Console.WriteLine("Select a document to edit:");
            ListDocuments();
            Console.Write("Enter document name: ");
            string docName = Console.ReadLine() ?? "";

            // Loop through the documents to find the one with the matching name
            Document? document = null;
            foreach (var doc in Document.Documents)
            {
                if (doc.Name.ToLower() == docName.ToLower())
                {
                    document = doc;
                    break; // Exit the loop once the document is found
                }
            }

            if (document == null)
            {
                // Notify the user if the document is not found
                Console.WriteLine("Document not found.");
                return;
            }

            // Check if the current user has permission to edit the document
            // Check if the currentUser is not null and has permission to edit the document
            if (currentUser == null || document.Owner != currentUser && !document.Collaborators.Contains(currentUser))
            {
                Console.WriteLine("You do not have permission to edit this document.");
                return;
            }


            // Check if the document is in a state that allows editing
            if (!(document.State is Draft || document.State is PushBack))
            {
                Console.WriteLine("Cannot edit document while it is under review.");
                return;
            }

            // Update the document content
            Console.Write("Enter new content: ");
            string content = Console.ReadLine() ?? "";
            document.Content = content;
            Console.WriteLine("Document content updated.");
        }
         static void ViewDocument(Document document)
        {
            if (currentUser == document.Owner || document.Collaborators.Contains(currentUser))
            {
                Console.Clear();
                Console.WriteLine($"Viewing document: {document.Name} ({document.Extension})");
                Console.WriteLine($"Content: {document.Content}");  // Assuming Document has Content property
                Console.WriteLine("\nPress any key to return.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You do not have permission to view this document.");
            }
        }
        // Method to list all documents owned by the current user
        static void ListOwnedDocuments()
        {
            if (currentUser == null) 
            {
                Console.WriteLine("No user is currently logged in.");
                return;
            }

            if (currentUser is not Owner owner || owner.OwnedDocuments.Count == 0)
            {
                Console.WriteLine("You do not own any documents.");
                return;
            }

            List<Document> filteredDocuments = owner.OwnedDocuments;
            IDocumentFilterStrategy? filterStrategy = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{currentUser.Name}'s owned documents:\n");

                foreach (var doc in filteredDocuments)
                {
                    Console.WriteLine($"{doc.Name} ({doc.Extension})");
                }

                Console.WriteLine("\nOptions: (V)iew document, (F)ilter, (N)ext, (P)revious, (Q)uit");
                string userChoice = Console.ReadLine()?.ToLower() ?? "";

                if (userChoice == "q") break;

                if (userChoice == "f")
                {
                    Console.WriteLine("Filter by: (1) File Type, (2) Name, (3) Collaborator, (C) Clear Filters");
                    string filterChoice = Console.ReadLine()?.ToLower() ?? "";

                    switch (filterChoice)
                    {
                        case "1":
                            Console.Write("Enter file type (e.g., .pdf, .docx): ");
                            string extension = Console.ReadLine() ?? "";
                            filterStrategy = new FileTypeFilter(extension);
                            break;

                        case "2":
                            Console.Write("Enter document name keyword: ");
                            string name = Console.ReadLine() ?? "";
                            filterStrategy = new NameFilter(name);
                            break;

                        case "3":
                            Console.Write("Enter collaborator name: ");
                            string collaboratorName = Console.ReadLine() ?? "";
                            User? collaborator = users.FirstOrDefault(u => u.Name.Equals(collaboratorName, StringComparison.OrdinalIgnoreCase));

                            if (collaborator != null)
                                filterStrategy = new CollaboratorFilter(collaborator);
                            else
                                Console.WriteLine("User not found.");
                            break;

                        case "c":
                            filterStrategy = null;
                            break;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                    filteredDocuments = filterStrategy != null ? filterStrategy.Filter(owner.OwnedDocuments) : owner.OwnedDocuments;
                }
            }
        }

    }
}