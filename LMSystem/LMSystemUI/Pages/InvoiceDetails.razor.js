export function showModal(elementId) {
    if (elementId != null && elementId != undefined) {
        let modalElement = document.getElementById(elementId);
        modalElement.style.display = "block";
        return "ok";
    } else { return "error"; }
}

export function hideModal(elementId) {
    if (elementId != null && elementId != undefined) {
        let modalElement = document.getElementById(elementId);
        modalElement.style.display = "none";
        return "ok";
    } else { return "error"; }
}