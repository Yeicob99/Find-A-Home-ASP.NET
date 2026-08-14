	const provinceSelect = document.getElementById("provinceSelect");
	const zoneSelect = document.getElementById("zoneSelect");

	provinceSelect.addEventListener("change", async function () {
			const provinceId = this.value;

	zoneSelect.innerHTML =
	'<option value="">Seleccione una zona</option>';

	if (!provinceId) {
		zoneSelect.disabled = true;
	return;
		}

	const response = await fetch(`/Home/GetZonesByProvince?provinceId=${provinceId}`);

	const zones = await response.json();

	zones.forEach(function(zone) {
			const option = document.createElement("option");

	option.value = zone.id;
	option.textContent = zone.name;

	zoneSelect.appendChild(option);
		});

	zoneSelect.disabled = false;

		});
