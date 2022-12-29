extends Node


func LoadScene(path):
	print(path)
	get_tree().change_scene(path)


func _on_Button2_pressed():
	LoadScene("res://Scenes/Change.tscn")
