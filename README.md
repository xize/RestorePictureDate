# This is the readme file for RestorePictureDate
<img width="280" height="428" alt="image" src="https://github.com/user-attachments/assets/38dd8dce-dcd8-4907-b4c4-067d7874c97f" />

## What does it?
Currently this program restores creation dates and modified dates by extracting this information from the metadata (EXIF).
Because the normal copy and paste behaviour in Windows can easily destroy the creation date, or modified date of a file just by moving or copying, if someone wants to place back the photos the ordering is otherwise broken, this program is designed to try to fix this problem.

## NOTE this is important:
if you experience problems with a disabled button inside the filebrowser controls, likely you try to copy files directly from a device which doesn't use normal copy and paste streams,
from or to Android devices but also Apple devices these have a different way of copying and pasting which on Windows you won't notice this distinction but it is a important one.

for this case, it is recommended to copy the camera files to windows, and then use this program, you can also paste it back directly on the Android/Apple device without sacrificing that the date gets modified again because it is not a normal copy paste Windows won't touch it here.

the problem only appears when one copies files inside Windows to a location in Windows, this will then override the modified date and creation date which messes up ordering once these modified pictures get copied over to the Android device. 
