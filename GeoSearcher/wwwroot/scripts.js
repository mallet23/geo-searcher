class GeoManager {
    openTab = (tab) => {
        const toggleClass = this._toggleClass;
        const activeElements = [].slice.call(document.getElementsByClassName("active"));
        activeElements.forEach(function (el) {
            toggleClass(el, "active", false);
        });

        const selectedElements = [].slice.call(document.getElementsByClassName(tab));
        selectedElements.forEach(function(el) {
            toggleClass(el, "active", true);
        });
    }

    getLocationByIP = async () => {
        const input = document.getElementById("ip-address");
        await this._makeRequest(`ip/location?ip=${input.value}`);
    }

    getLocationByCity = async (e) => {
        const input = document.getElementById("city-name");
        await this._makeRequest(`city/locations?city=cit_${input.value}`);
    }

    _makeRequest = async (url) => {
        let response = await fetch(url);

        if (response.status !== 200) {
            console.error(response.statusText);
        }

        const result =  await response.json();
        this._setResult(result);
    }

    _setResult = (result) => {
        const hasResult = !this._isNullOrEmpty(result);

        const output = document.querySelector(".active .output");
        output.innerText = hasResult ? this._beautifyJson(result) : "";

        const emptyOutput = document.querySelector(".active .output-empty");
        this._toggleClass(emptyOutput, "hidden", hasResult);
    }

    _isNullOrEmpty = (value) => {
        return value === undefined
            || value === null
            || value === ""
            || (Array.isArray(value) && value.length === 0);
    }

    _toggleClass = (element, className, state) => {
        if (state) {
            element.classList.add(className);
        } else {
            element.classList.remove(className);
        }
    }

    _beautifyJson = (jsonResponse) => {
        return JSON.stringify(jsonResponse, null, 4);
    }
} 

const GeoController =  new GeoManager();