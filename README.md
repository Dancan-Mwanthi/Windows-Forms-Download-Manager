# DownloadMaster

## Overview

DownloadMaster is a Windows Forms application developed in C# that serves as a download manager. The project aims to provide a user-friendly interface for managing and organizing downloads, with a focus on mimicking some features of Internet Download Manager (IDM) through reverse engineering.

## Features

1. **User-Friendly Interface:**
   - The application provides a clean and intuitive Windows Forms interface for users to manage their downloads easily.

2. **Download Management:**
   - Users can add, pause, resume, and remove downloads.
   - The download list displays essential information such as file name, progress, size, and download speed.

3. **Multi-threaded Downloads:**
   - The application utilizes multi-threading to download files concurrently, optimizing download speeds.

4. **Download Queue:**
   - Users can organize their downloads by queuing multiple files for sequential downloading.

5. **Download History:**
   - Download history is maintained, allowing users to track and review their past downloads.

6. **User Authentication:**
   - Support for basic user authentication for websites that require login credentials for downloading.

7. **Browser Integration:**
   - Integration with web browsers to capture download requests and add them to the DownloadMaster queue.

8. **IDM-like Features:**
   - Attempt to incorporate some features inspired by Internet Download Manager for an enhanced user experience.

## System Requirements

- Windows operating system (tested on Windows 7, 8, 10)
- .NET Framework 4.5 or later

## Getting Started

1. **Clone the Repository:**

2. **Open Solution:**
- Open the solution file (`DownloadMaster.sln`) in Visual Studio.

3. **Build Solution:**
- Build the solution to resolve dependencies and compile the application.

4. **Run the Application:**
- Start the application from Visual Studio or locate the executable in the `bin` directory.

## Usage

1. **Adding a Download:**
- Click on the "Add Download" button and enter the URL of the file you want to download.

2. **Managing Downloads:**
- Pause, resume, or remove downloads using the corresponding buttons in the application.

3. **Download Queue:**
- Organize downloads by queuing multiple files for sequential downloading.

4. **Download History:**
- Access the download history to view details of past downloads.

5. **User Authentication:**
- Configure user authentication settings for websites that require login credentials.

6. **Browser Integration:**
- Enable browser integration to capture download requests from web browsers.

## Known Issues

1. **System.Net.WebException: The remote server returned an error: (403) Forbidden.**
- **Issue Description:** Users may encounter a `System.Net.WebException` with the error message indicating that the remote server returned an error with status code 403 (Forbidden).
- **Resolution:** This issue has been resolved by making the download process asynchronous. The application now handles web requests more efficiently, reducing the likelihood of encountering 403 errors.
  
## Contribution Guidelines

We welcome contributions to enhance the features and stability of DownloadMaster. If you wish to contribute:

1. Fork the repository and create a new branch for your feature or bug fix.
2. Ensure that your code follows the established coding standards.
3. Submit a pull request with a detailed description of your changes.

## Acknowledgments

Special thanks to the developers of Internet Download Manager for inspiration.
