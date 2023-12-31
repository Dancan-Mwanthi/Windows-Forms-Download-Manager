# wf_DownloadManager
An ideal learning project focusing on asynchronous operations and advanced C# topics for developers, delivered through a download manager that not only supports HTTP and FTP downloads but will soon extend its capabilities to include BitTorrent, Magnet, and more.

## Overview

DownloadMaster is a Windows Forms application developed in C# that serves as a download manager. The project aims to provide a user-friendly interface for managing and organizing downloads, with a focus on mimicking some features of Internet Download Manager (IDM) through reverse engineering.

# `Requires .NET >= 6`

## Functionality Highlights

- Seamless downloading of large files even when the application is in the background.
- Background-enabled file downloads for uninterrupted task execution.
- Concurrent downloading of multiple files for enhanced efficiency.
- Capable to resume downloads that were interrupted.
- Users have the option to pause ongoing downloads.

## Clone the Repository
   ````
https://github.com/Dancan-Mwanthi/wf_DownloadManager.git
````
## Known Issues

1. **System.Net.WebException: The remote server returned an error: (403) Forbidden.**
- **Issue Description:** Users may encounter a `System.Net.WebException` with the error message indicating that the remote server returned an error with status code 403 (Forbidden).
- **Resolution:** This issue has been resolved by making the download process asynchronous. The application now handles web requests more efficiently, reducing the likelihood of encountering 403 errors.

  ````csharp
  using (var webResponse = await request.GetResponseAsync().ConfigureAwait(false))

## Code Optimization

In the latest version of wf_DownloadManager, an optimization has been made in; 

1. How controls are retrieved within the application. The method for retrieving controls now utilizes a generic method, enhancing the efficiency of control retrieval. Below is an example of the optimized code:

   ````csharp
    T _GetControl<T>(string controlName) where T : Control, new() =>
    _form.Controls.Find(controlName, true).OfType<T>().FirstOrDefault() ?? new T();
   ````

2. Freezing when a download is added. Optimized the the threading to eliminate thread locking.

   Previous Code
   `````csharp
   Thread downloadThread = new Thread(async () =>
    {
      
    });
   
    xdownloadThreads.Add(downloadThread);
   
    downloadThread.Start();
   ``````
   
   Current Code
      ````csharp
   await Task.Run(async () =>
   {
      
   });
   ````
  
## Contribution Guidelines

We welcome contributions to enhance the features and stability of wf_DownloadManager. If you wish to contribute:

1. Fork the repository and create a new branch for your feature or bug fix.
2. Ensure that your code follows the established coding standards.
3. Submit a pull request with a detailed description of your changes.

## Acknowledgments

Special thanks to the developers of Internet Download Manager for inspiration.
