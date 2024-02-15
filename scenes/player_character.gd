extends CharacterBody2D
class_name PlayerCharacter

const SPEED = 148.8
@onready var name_tag = $NameTag
@onready var peer_id_tag = $PeerIdTag

var global_world_root: GlobalWorldRoot
var controls_frozen: bool = false

func _enter_tree():
	# Server and Clients all agree that multiplayer authority belongs to this name/peer_id
	set_multiplayer_authority(str(name).to_int())
	
	global_world_root = get_parent()
	
func _ready():
	# Only allow the authority of this node to run functions like this
	if not is_multiplayer_authority(): return
	
	# Set your name (peer_id) into the peer id tag
	peer_id_tag.text = name
	# Set your player name from the global UI
	name_tag.text = global_world_root.main_menu.player_name_entry.text
	
	$Camera2D.make_current()

func _physics_process(_delta):
	if not is_multiplayer_authority(): return
	
	if controls_frozen:
		return
	
	var direction := Vector2(
		Input.get_action_strength("ui_right") - Input.get_action_strength("ui_left"), 
		Input.get_action_strength("ui_down") - Input.get_action_strength("ui_up")
	)
	if direction:
		velocity = direction.normalized() * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.y = move_toward(velocity.y, 0, SPEED)

	move_and_slide()

func freeze_character_controls():
	controls_frozen = true

func unfreeze_character_controls():
	controls_frozen = false

@rpc("call_local", "any_peer", "reliable")
func get_kissed():
	if multiplayer.get_remote_sender_id() == get_multiplayer_authority():
		return # you cant kiss yourself silly
	$LoveParticles.restart()
	$LoveParticles.emitting = true
