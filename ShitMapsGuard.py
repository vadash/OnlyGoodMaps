import time
from win10toast import ToastNotifier
from playsound import playsound

toaster = ToastNotifier()
file = open('C:\\games\\poe\\logs\\Client.txt', 'r')
file.seek(0, 2)

maps = ["Academy",
        "Ancient City",
        "Arena",
        "Armoury",
        "Bone Crypt",
        "Cage",
        "Cells",
        "Colloseum",
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

playsound("Media\\Cancer.wav")
while 1:
	where = file.tell()
	line = file.readline()
	if not line:
		time.sleep(1)
		file.seek(where)
	else:
		print(line)
		for map in maps:
			if map in line:
                                toaster.show_toast("DO NOT RUN MAP", map)
                                toaster.show_toast("DO NOT RUN MAP", map)
                                toaster.show_toast("DO NOT RUN MAP", map)
                                playsound("Media\\Cancer.wav")