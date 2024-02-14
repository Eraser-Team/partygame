extends Node

var timer = 14

func _process(delta):
	timer -= delta
	if timer <= 0:
		get_tree().change_scene_to_file("res://multiplayer.tscn")
