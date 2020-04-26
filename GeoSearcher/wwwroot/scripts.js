const openTab = function(tab) {
    const activeElements = [].slice.call(document.getElementsByClassName("active"));
    activeElements.forEach(function (el) {
        toggleClass(el, "active", false);
    });

    const selectedElements = [].slice.call(document.getElementsByClassName(tab));
    selectedElements.forEach(function(el) {
        toggleClass(el, "active", true);
    });
};

const getLocationByIP = function () {
    
    const input = document.getElementById("ip-address");

    request("GET", "api/ip/" + input.value + "/location", setResult);

    return false;
}

const getLocationByCity = function () {
    const input = document.getElementById("city-name");

    request("GET", "api/city/cit_" + input.value + "/locations", setResult);

    return false;
}

const setResult = function (responseText) {
    const result = responseText && JSON.parse(responseText);
    const hasResult = !isNullOrEmpty(result);

    const output = document.querySelector(".active .output");
    output.innerText = hasResult ? beautifyJson(result) : "";

    const emptyOutput = document.querySelector(".active .output-empty");
    toggleClass(emptyOutput, "hidden", hasResult);
}

const isNullOrEmpty = function (value) {
    return value === undefined
        || value === null
        || value === ""
        || (Array.isArray(value) && value.length === 0);
}

const toggleClass = function (element, className, state) {
    if (state) {
        element.classList.add(className);
    } else {
        element.classList.remove(className);
    }
} 

const beautifyJson = function(jsonResponse) {
    return JSON.stringify(jsonResponse, null, 4);
}

const request = function (method, url, onload) {
    const xhr = new XMLHttpRequest();
    
    xhr.open(method, url, true);
    xhr.onload = function (e) {
        if (xhr.readyState === 4) {
            onload(xhr.responseText);

            if (xhr.status !== 200) {
                console.error(xhr.statusText);
            }
        }
    };
    xhr.onerror = function (e) {
        console.error(xhr.statusText);
    };
    xhr.send();
}