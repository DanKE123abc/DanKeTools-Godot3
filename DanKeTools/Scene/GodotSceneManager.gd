extends Node


func LoadScene(path):
	print(path)
	get_tree().change_scene("res://Scenes/Change.tscn")


func _on_Button2_pressed():
	LoadScene("res://Scenes/Change.tscn")
