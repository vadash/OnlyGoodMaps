import time
from win10toast import ToastNotifier
from playsound import playsound
import psutil

def checkIfProcessRunning(processName):
    '''
    Check if there is any running process that contains the given name processName.
    '''
    #Iterate over the all the running process
    for proc in psutil.process_iter():
        try:
            # Check if process name contains the given name string.
            if processName.lower() in proc.name().lower():
                return True
        except (psutil.NoSuchProcess, psutil.AccessDenied, psutil.ZombieProcess):
            pass
    return False;

toaster = ToastNotifier()

maps = ["Academy",
        "Ancient City",
        "Arena",
        "Armoury",
        "Bone Crypt",
        "Cage",
        "Cells",
        "Colosseum",
        "Conservatory",
        "Coral Ruins",
        "Core",
        "Courtyard",
        "Cursed Crypt",
        "Desert",
        "Dungeon",
        "Factory",
        "Flooded Mine",
        "Gardens",
        "Ivory Temple",
        "Lava Chamber",
        "Maze",
        "Mineral Pools",
        "Museum",
        "Necropolis",
        "Orchard",
        "Overgrown Ruin",
        "Overgrown Shrine",
        "Palace",
        "Pen",
        "Pier",
        "Pit",
        "Plaza",
        "Precinct",
        "Residence",
        "Scriptorium",
        "Shrine",
        "Sunken City",
        "Vaal Pyramid",
        "Villa",
        "Wasteland"] 

with open('C:\\games\\poe\\logs\\Client.txt', 'r') as f:
        f.seek(0, 2)
        while True:
            if not checkIfProcessRunning('PathOfExile_x64'):
                quit()
            line = f.readline()
            if not line:
                time.sleep(2)
                continue
            print(line)
            if not "You have entered" in line:
                continue
            for map in maps:
                if map in line:
                    playsound("Media\\Cancer.wav")
                    toaster.show_toast("DO NOT RUN MAP", map)

