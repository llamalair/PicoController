# Raspberry Pi Pico 2020 Software & Hardware Integration 

A project that connects the raspberry pi light to a WPF software focusing on the software side rather than the hardware side. 
Utilise WPF to create a UI coded in .xaml and C# that interacts with the backend Raspberry PI coded in C++ 

To be improved on : 

1. make it MVVM 
2. make it OOD 


<img width="1258" height="581" alt="image" src="https://github.com/user-attachments/assets/bede83b4-088e-4a00-9b82-1982a93fbaa0" />

# Hardware

## User Instruction: 

### Mounting a device 

**Manually if your system doesnt automatically:**

To show the last few kernel messages 
```bash
dmesg | tail 
```

Create a file in mnt ( mount - temporary location to attach file system ) ( -p make sure parent /mnt is there else fail )
```bash
sudo mkdir -p /mnt/pico 
```

Mount the sda1 ( scsi disk , a,b,c the order detected , 1,2,3 the partition ) from dev ( device entry points into devices managed by the kernel ) 
sda vs sda1   
sda : is just the metadata describing the partition   
sda1 : is the 1st partition ( the real file system )  
```bash
sudo mount /dev/sda1 /mnt/pico
```
Now when you go into /mnt/pico you should see the files of pico 

Then all you need to do is copy your existing .uf2 file into /mnt/pico
```bash
sudo cp filename.uf2 /mnt/pico
```
After doing that your /mnt/pico device should be gone as its not detected as a filesystem anymore ( It's disconnected )

Else if its still there do : 
```bash
sudo sync
sudo umount /mnt/pico
```

But ussually it should unmount on its own 

### Create your .uf2 file

**Three main of doing that:** 

1. Thornny: ( Python )7.0
Download the RPI_PICO-2O251209-v1.2.uf2 (something along the lines of this) from the website depending on your raspberry pi model  
pico and picoWH is different  
Once you download it drag and drop the file into your device , or manually flash it   
Then you can use Thornny to talk to it   

2. Visual Studio Code Extension: ( C/C++ )
Download the RaspberryPi Extension then press the button and follow the instruction, then compile it 

3. Manually Flashing it: ( C/C++ )
mkdir a new folder  
gitclone the raspberrypi repo   
cp the Cmakelist.txt out   
install all the require compiler (cmake)  
then compile it   
it should create a build folder   
then 
.make the build to create the .uf2 file 

### Flashing your file into the device 
Press the button of your device so it go into BOOTSEL mode  
While holding the button plug in your usb into it 

### Unmount 
Once you unmount your device  
Your PC/laptop wont detect it anymore ( as no files are being send anymore ) - you have to talk to it for the PC to recognise it  
Cause right now its just supplying power to the device  


# Software 
Have to use visual studio instead of visual code  
Device talk to PC through USB using SerielPort library ( You have to download the library )

WPF Part of it:




 

