# GMADB
v0.2 Beta

GMADB is a GUI based Minimal ADB that helps you work on modifying your Android device via the Android Debug Bridge. This program helps you to speed up your process of sideloading an update to your android device by making the UX easier. It has four main functionalities:

![gmadb1](https://user-images.githubusercontent.com/21107275/123399242-0047a880-d5c2-11eb-9fac-849b98cd85d5.png)


1. Select and Flash - This allows you to simply select the .zip or .img file of the update and flash it with just a single click. All the process happening will be displayed on the blackBoard (the big black textbox that looks like a terminal window).

2. ADB Devices - With one click, it displays all the available/connected devices on Android Debug Bridge (ADB).


3. Custom Command - This helps you to execute custom shell commands from the app, making it easier for you to do any operation without going to cmd.

4. Log recorder - The application generates a log file of all your activities, which will help you to debug or evaluate all the errors, outputs and everything that was on the blackBoard. (Will be available from the next update)


### How to use:

After building the project or extracting the pre-built packages, follow these steps: 

![gmadb2](https://user-images.githubusercontent.com/21107275/123399260-06d62000-d5c2-11eb-9f7f-a5ac5ef0c9ea.png)


step 1: Click on the "Select ROM" button. Select the .zip file from the file explorer window that opens up. The selected filename will be displayed and the Flash button will become active (Bright green color).

step 2: Click the "Flash" Button. Wait for the process to complete. Do not close the window until you see the success message on the screen. (In the current version, real-time process output streaming is not available (will be fixed in the upcoming updates), so DO-NOT close the window assuming that the process is not happening. Please refer the phone for the process progress information.)

### Known bugs:

1. The results/output shown on blackBoard is not real-time. Output appears only after the completion of the process
2. Runs on a single thread
3. Log Generator yet to be implemented
