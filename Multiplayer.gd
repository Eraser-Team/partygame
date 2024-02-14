extends Node2D

var peer = ENetMultiplayerPeer.new()
@export var player_scene: PackedScene


func _on_button_2_pressed():
	peer.create_server(8606)
	multiplayer.multiplayer_peer = peer
	multiplayer.peer_connected.connect(_add_player)
	_add_player()
	
func _add_player(id = 1):
	var player = player_scene.instantiate()
	player.name = str(id)
	call_deferred("add_child", player)

func _on_button_pressed():
	peer.create_client("26.9.122.242", 8606)
	multiplayer.multiplayer_peer = peer
