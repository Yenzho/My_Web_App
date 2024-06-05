# My Web Application

This is a web application developed with .NET Core and a CSS framework (Bootstrap recommended) for managing users. It includes features for registration, authentication, and user management.

## Features

- **User Registration and Authentication**: Users can register and log in to the application. Non-authenticated users can only access the registration and login forms.
- **User Management**: Authenticated users have access to a user management table displaying user details such as ID, name, email, last login time, registration time, and status (active/blocked).
- **User Actions**: Users can block, unblock, and delete themselves or any other user.
- **Toolbar Actions**: The toolbar above the user management table includes actions to Block (red button with text), Unblock (icon), and Delete (icon) selected users.
- **Checkbox Selection**: The leftmost column of the user management table contains checkboxes for multiple selection, with a checkbox in the table header to select or deselect all records.
- **Redirection**: Blocked users cannot log in, and deleted users can re-register. If a user account is blocked or deleted, any subsequent request redirects to the login page.

## Requirements

- .NET Core
- A CSS framework (Bootstrap recommended)
- A database for storing user details
- Docker

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Yenzho/My_Web_App.git
   cd My_Web_App

